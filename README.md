# Rocket_Graph_API

<!-- ABOUT THE PROJECT -->
## About The Project

Rocket Elevators Graph API is the 6th project for the Odyssey 14 weeks program in CodeBoxx. 

By the 5th week We have added APIs using Ruby on Rails to the website created in the Genesis Program. 

website used: [rocketelevators-jt.com/](http://rocketelevators-jt.com/)

##

For the 6th week, we have created a rest API with 9 endpoints and a graphql API. They are both deployed on Microsoft Azure.

<br>

##  Required Graph API endpoints exemples

- Retrieving the address of the building, the beginning and the end of the intervention for a specific intervention.
  > https://rocketelevatorgraphqlapi.azurewebsites.net/graphql/
 ```
  query{
  getSpecificInterventions(id: 15){
    item1{
      id
      buildingId
      dateAndTimeInterventionStart
      dateAndTimeInterventionEnd
    }
    item2{
      id
      address{
        typeAddress
        numberAndStreet
        city
        country
      }
    }
  }
}
```

- Retrieving customer information and the list of interventions that took place for a specific building.
> https://rocketelevatorgraphqlapi.azurewebsites.net/graphql/
```
  query{
  getSpecificBuildingsWithBuildingID(id: 15){
    item1{
      id
      emailAdministrator
      customer{
        compagnyName
        contactPhone
        email
      }
    }
    item2{
      id
      dateAndTimeInterventionStart
      dateAndTimeInterventionEnd
    }
  }
}
```

- Retrieving the current status of a specific Column
  > https://rocketelevatorgraphqlapi.azurewebsites.net/graphql/
 
```
  query{
  getSpecificBuildingsWithEmployeeID(id: 21){
    item1{
      id
      userId
      email
      firstName
      lastName
    }
    item2{
      id
      emailAdministrator
      phoneNumberAdministrator
      listIntervention{
        employeeId
        dateAndTimeInterventionStart
        dateAndTimeInterventionEnd
      }
      listBuildingDetails{
        buildingId
        informationKey
        value
      }
    }
  }
}
```

## Contributors

- **[Ted Lemy](https://github.com/lemyted)**
- **[Alex Wallot](https://github.com/AlexWallot)**
- **[Luka Trudel](https://github.com/LukaTrudel)**
- **[Rafik Hoceini](https://github.com/rafikhoceini)**
- **[Armughan Ayaz Janjua](https://github.com/armughanayaz)**
