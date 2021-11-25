using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HotChocolate;
using DotNetGQL.Model;
using System.Threading.Tasks;

public class Query{
    public Tuple<Building, List<FactIntervention>> getSpecificBuildingsWithBuildingID([Service] Rocket_Elevators_Information_System_developmentContext mySQLContext, [Service] data_warehouseContext postGresContext,int id)
    {
        var building = mySQLContext.Buildings.FirstOrDefault(a => a.Id == id);
        IQueryable<FactIntervention> fact = postGresContext.FactInterventions.Where(a => a.BuildingId == id);
        List<FactIntervention> factlist = fact.ToList();
        return Tuple.Create(building,factlist);
    }

    public Tuple<FactIntervention,Building> getSpecificInterventions([Service] data_warehouseContext postGresContext, [Service] Rocket_Elevators_Information_System_developmentContext mySQLContext, int id)
    {
        FactIntervention fact = postGresContext.FactInterventions.FirstOrDefault(a => a.ElevatorId == id);
        Building building = mySQLContext.Buildings.FirstOrDefault(a => a.Id == fact.BuildingId);
        return Tuple.Create(fact,building);
    }

    public Tuple<Employee, List<BuildingDTO>> getSpecificBuildingsWithEmployeeID([Service] Rocket_Elevators_Information_System_developmentContext mySQLContext, [Service] data_warehouseContext postGresContext,int id)
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
}