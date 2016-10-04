using Chinook.Framework.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Profile_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            int custId = 1;
            CustomerManager manager = new CustomerManager();
            var theProfile = manager.GetProfile(custId);
            FirstName.Text = theProfile.FirstName;
            LastName.Text = theProfile.LastName;
            CompanyName.Text = theProfile.CompanyName;
            StreetAddress.Text = theProfile.StreetAddress;
            City.Text = theProfile.City;
            Country.Text = theProfile.Country;
            PostalCode.Text = theProfile.PostalCode;
        }

    }
}