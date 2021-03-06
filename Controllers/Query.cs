using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HotChocolate;
using System.Threading.Tasks;
using DotNetGQL.Model;

public class Query{

    public Tuple<FactIntervention,Building> getSpecificInterventions([Service] Alex_WallotContext postGresContext, [Service] AlexWallotContext mySQLContext, int id)
    {
        FactIntervention fact = postGresContext.FactInterventions.FirstOrDefault(a => a.Id == id);
        Building building = mySQLContext.Buildings.FirstOrDefault(a => a.Id == fact.BuildingId);
        return Tuple.Create(fact,building);
    }

    public Tuple<Building, List<FactIntervention>> getSpecificBuildingsWithBuildingID([Service] AlexWallotContext mySQLContext, [Service] Alex_WallotContext postGresContext,int id)
    {
        var building = mySQLContext.Buildings.FirstOrDefault(a => a.Id == id);
        IQueryable<FactIntervention> fact = postGresContext.FactInterventions.Where(a => a.BuildingId == id);
        List<FactIntervention> factlist = fact.ToList();
        return Tuple.Create(building,factlist);
    }

    // get all building with an employee id. this method return a list of buildingDTO with a list of interventions and a list of buildingDetails
    public Tuple<Employee, List<BuildingDTO>> getSpecificBuildingsWithEmployeeID([Service] AlexWallotContext mySQLContext, [Service] Alex_WallotContext postGresContext,int id)
    {
        Employee employee = mySQLContext.Employees.FirstOrDefault(a => a.Id == id);
        List<FactIntervention> factlist = postGresContext.FactInterventions.Where(a => a.EmployeeId == employee.Id).ToList();
        BuildingDTO building;
        List<BuildingDTO> buildings = new List<BuildingDTO>();
        foreach (var item in factlist)
        {
            Building building1 = mySQLContext.Buildings.FirstOrDefault(a => a.Id == item.BuildingId);
            building = new BuildingDTO(building1.Id,building1.CustomerId,building1.AddressId,building1.FullNameAdministrator,building1.EmailAdministrator,building1.PhoneNumberAdministrator,building1.FullNameTechnicalContact,building1.EmailTechnicalContact,building1.PhoneTechnicalContact);
            if (buildings.Contains(building) == false)
            {
                List<FactIntervention> factlists = postGresContext.FactInterventions.Where(a => a.EmployeeId == employee.Id && a.BuildingId == building.Id).ToList();
                building.ListIntervention = factlist;
                List<BuildingDetail> detailsList = mySQLContext.BuildingDetails.Where(a => a.BuildingId == building.Id).ToList();
                building.ListIntervention = factlists;
                building.ListBuildingDetails = detailsList;
                buildings.Add(building);
            }
        }
        return Tuple.Create(employee,buildings);
    }

    public List<Battery> getAllBatteries([Service] AlexWallotContext mySQLContext)
    {
        var batteries = mySQLContext.Batteries.ToList();
        return batteries;

    }

    public string getBatteryStatus([Service] AlexWallotContext mySQLContext,long id)
    {
        var battery = mySQLContext.Batteries.Where(battery => battery.Id == id).ToList();
        return battery[0].Status;
    }

    public Battery updateBatteryStatus([Service] AlexWallotContext mySQLContext,long id, string status)
    {
        var battery = mySQLContext.Batteries.Where(battery => battery.Id == id).ToList();
        battery[0].Status = status;
        return battery[0];

    }


    public string getElevatorStatus([Service] AlexWallotContext mySQLContext,long id)
    {
        var elevator = mySQLContext.Elevators.Where(elevator => elevator.Id == id).ToList();
        return elevator[0].Status;
    }

    public List<Lead> getLeads([Service] AlexWallotContext mySQLContext) 
    {
        var leads = mySQLContext.Leads.ToList();
        var customers = mySQLContext.Customers.ToList();
        List<Lead> notCustomers = new List<Lead>();

        DateTime currentDate = DateTime.Now;
        List<Lead> filteredLeads = leads.Where(lead => lead.CreatedAt > currentDate.AddDays(Convert.ToDouble(-30))).ToList();
        List<Customer> filteredCustomers = customers.Where(customer => customer.CreatedAt > currentDate.AddDays(Convert.ToDouble(-30))).ToList();

        foreach (Lead lead in leads) 
        {
            foreach (Customer customer in customers) 
            {
                if (lead.Email != customer.Email && lead.PhoneNumber != customer.ContactPhone) {
                    notCustomers.Add(lead);
                    return notCustomers;
                }
            }
        }
        return notCustomers;
    }

    public Building buildingsFindById(long id, List<Building> listBuilding) 
    {
        foreach (Building building in listBuilding) 
        {
            if (building.Id == id) 
            {
                return building;
            }
        }
        return null;
    }

    public List<Building> getBuildings([Service] AlexWallotContext mySQLContext)
    {
        var buildings = mySQLContext.Buildings.ToList();
        var batteries = mySQLContext.Batteries.ToList();
        var columns = mySQLContext.Columns.ToList();
        var elevators = mySQLContext.Elevators.ToList();

        var filteredBatteries = batteries.Where(battety => battety.Status == "intervention").ToList();
        var filteredColumns = columns.Where(column => column.Status == "intervention").ToList();
        var filteredElevators = elevators.Where(elevator => elevator.Status == "intervention").ToList();

        List<Building> result = new List<Building>();
        foreach (Battery battery in filteredBatteries) 
        {
            var containerBuilding = buildingsFindById(battery.BuildingId, buildings);
            if (containerBuilding != null && battery.getColumnList(filteredColumns, filteredElevators) && !result.Contains(containerBuilding)) 
            {
                result.Add(containerBuilding);
            }
        }
        return result;
    }

    public List<Elevator> getElevatorsOffline([Service] AlexWallotContext mySQLContext)
    {
        return mySQLContext.Elevators
                .Where(elevator => elevator.Status == "offline" || elevator.Status == "maintenance")
                .ToList();

    }


    public Elevator updateElevatorStatus([Service] AlexWallotContext mySQLContext, long id, string status) 
    {
        var chosenOne = mySQLContext.Elevators.Where(elevator => elevator.Id == id).ToList();
        chosenOne[0].Status = status;
        mySQLContext.SaveChanges();
        return chosenOne[0];
    }

    public string getSpecificElevatorStatus([Service] AlexWallotContext mySQLContext, long id) 
    {
        var chosenOne = mySQLContext.Elevators.Where(elevator => elevator.Id == id).ToList();
        return chosenOne[0].Status;
    }

    public Column updateColumnStatus([Service] AlexWallotContext mySQLContext, long id, string status) 
    {
        var chosenOne = mySQLContext.Columns.Where(col => col.Id == id).ToList();
        chosenOne[0].Status = status;
        mySQLContext.SaveChanges();
        return chosenOne[0];
    }

    public string getSpecificColumnStatus([Service] AlexWallotContext mySQLContext, long id) 
    {
        var chosenOne = mySQLContext.Columns.Where(col => col.Id == id).ToList();
        return chosenOne[0].Status;
    }
}