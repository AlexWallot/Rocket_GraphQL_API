using System.Collections.Generic;
using DotNetGQL.Model;

public partial class BuildingDTO{

    public long Id { get; set; }
    public long? CustomerId { get; set; }
    public long? AddressId { get; set; }
    public string FullNameAdministrator { get; set; }
    public string EmailAdministrator { get; set; }
    public string PhoneNumberAdministrator { get; set; }
    public string FullNameTechnicalContact { get; set; }
    public string EmailTechnicalContact { get; set; }
    public string PhoneTechnicalContact { get; set; }
    public List<FactIntervention> ListIntervention { get; set; }
    public List<BuildingDetail> ListBuildingDetails { get; set; }

    public BuildingDTO(long id, long? customerId, long? addressId, string fullNameAdministrator, string emailAdministrator, string phoneNumberAdministrator, string fullNameTechnicalContact, string emailTechnicalContact, string phoneTechnicalContact){
        this.Id = id;
        this.CustomerId = customerId;
        this.AddressId = addressId;
        this.FullNameAdministrator = fullNameAdministrator;
        this.EmailAdministrator = emailAdministrator;
        this.PhoneNumberAdministrator = phoneNumberAdministrator;
        this.FullNameTechnicalContact = fullNameTechnicalContact;
        this.EmailTechnicalContact = emailTechnicalContact;
        this.PhoneTechnicalContact = phoneTechnicalContact;
        this.ListIntervention = new List<FactIntervention>();
        this.ListBuildingDetails = new List<BuildingDetail>();
    }

}