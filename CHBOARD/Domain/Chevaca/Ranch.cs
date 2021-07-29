using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Domain.Chevaca
{
    public partial class Ranch
    {
        public int Ranch_ID { get; set; }
        public List<Person> Employees { get; set; }
        public int Ch_Organization_ID { get; set; }
        public List<Land> Lands { get; set; }
        public string Company_Rut { get; set; }
        public string Company_Name { get; set; }
        public string Company_Domain { get; set; }
        public string Company_SocialReason { get; set; }

        public string Company_Logo { get; set; }


        public Ranch()
        {
            Employees = new List<Person>();
            Lands = new List<Land>();
        }

        public Ranch(int chOrganizationId, string companyRut, string companyName, string companyDomain, string companySocialReason, string companyLogo)
        {
            Employees = new List<Person>();
            Ch_Organization_ID = chOrganizationId;
            Lands = new List<Land>();
            Company_Rut = companyRut;
            Company_Name = companyName;
            Company_Domain = companyDomain;
            Company_SocialReason = companySocialReason;
            Company_Logo = companyLogo;
        }


        public bool haveOwnerById(int vOwnerId)
        {
            bool owner_exist = false;
            int x = 0;
            
            while (x < Employees.Count && !owner_exist)
            {
                if (Employees[x].Person_ID == vOwnerId && Employees[x].IsOwner)
                {
                    owner_exist = true;
                }
                x++;
            }

            return owner_exist;
        }
    }
}
