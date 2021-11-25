using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HotChocolate;
using System.Threading.Tasks;
using DotNetGQL.Model;

public class Query{
    public Tuple<Building, List<FactIntervention>> getSpecificBuildingsWithBuildingID([Service] AlexWallotContext mySQLContext, [Service] Alex_WallotContext postGresContext,int id)
    {
        var building = mySQLContext.Buildings.FirstOrDefault(a => a.Id == id);
        IQueryable<FactIntervention> fact = postGresContext.FactInterventions.Where(a => a.BuildingId == id);
        List<FactIntervention> factlist = fact.ToList();
        return Tuple.Create(building,factlist);
    }

    public Tuple<FactIntervention,Building> getSpecificInterventions([Service] Alex_WallotContext postGresContext, [Service] AlexWallotContext mySQLContext, int id)
    {
        FactIntervention fact = postGresContext.FactInterventions.FirstOrDefault(a => a.ElevatorId == id);
        Building building = mySQLContext.Buildings.FirstOrDefault(a => a.Id == fact.BuildingId);
        return Tuple.Create(fact,building);
    }

    public Tuple<Employee, List<BuildingDTO>> getSpecificBuildingsWithEmployeeID([Service] AlexWallotContext mySQLContext, [Service] Alex_WallotContext postGresContext,int id)
    {
        var employee = mySQLContext.Employees.FirstOrDefault(a => a.Id == id);
        IQueryable<FactIntervention> fact = postGresContext.FactInterventions.Where(a => a.EmployeeId == employee.Id);
        List<FactIntervention> factlist = fact.ToList();
        BuildingDTO building;
        List<BuildingDTO> buildings = new List<BuildingDTO>();
        foreach (var item in factlist)
        {
            Building building1 = mySQLContext.Buildings.FirstOrDefault(a => a.Id == item.BuildingId);
            building = new BuildingDTO(building1.Id,building1.CustomerId,building1.AddressId,building1.FullNameAdministrator,building1.EmailAdministrator,building1.PhoneNumberAdministrator,building1.FullNameTechnicalContact,building1.EmailTechnicalContact,building1.PhoneTechnicalContact);
            if (buildings.Contains(building) == false)
            {
                List<FactIntervention> facts = postGresContext.FactInterventions.Where(a => a.EmployeeId == employee.Id && a.BuildingId == building.Id).ToList();
                List<FactIntervention> factlists = facts.ToList();
                building.ListIntervention = factlist;
                IQueryable<BuildingDetail> details = mySQLContext.BuildingDetails.Where(a => a.BuildingId == building.Id);
                List<BuildingDetail> detailsList = details.ToList();
                building.ListIntervention = factlists;
                building.ListBuildingDetails = detailsList;
                buildings.Add(building);
            }
        }
        var tuple = Tuple.Create(factlist,buildings);
        return Tuple.Create(employee,buildings);
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
}