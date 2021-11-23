using System;
using System.Collections.Generic;
using System.Linq;
using DotNetGQL.Model;
using Microsoft.EntityFrameworkCore;
using HotChocolate;
using System.Threading.Tasks;

public class Query{
    public async Task<IReadOnlyList<Building>> getBuildings([Service] Rocket_Elevators_Information_System_developmentContext mySQLContext)
    {
        return await mySQLContext.Buildings.ToListAsync();
    }
    public Building getSpecificBuildings([Service] Rocket_Elevators_Information_System_developmentContext mySQLContext,int id)
    {
        var building = mySQLContext.Buildings.FirstOrDefault(a => a.Id == id);
        return building;
    }

    public async Task<IReadOnlyList<Address>> getAddress([Service] Rocket_Elevators_Information_System_developmentContext mySQLContext)
    {
        return await mySQLContext.Addresses.ToListAsync();
    }

    public FactIntervention getInterventions([Service] data_warehouseContext postGresContext, int id)
    {
        FactIntervention fact = postGresContext.FactInterventions.FirstOrDefault(a => a.ElevatorId == id);
        return fact;
    }
}