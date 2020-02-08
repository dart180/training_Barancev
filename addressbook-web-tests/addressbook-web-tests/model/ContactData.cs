using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public ContactData(string firstname, string secondname)
        {
            Firstname = firstname;
            Secondname = secondname;
        }
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }

        public string allPhones;
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set { allPhones = value; }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "") return "";
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

        public string Id { get; set; }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Firstname == other.Firstname && Secondname == other.Secondname;
        }

        public override int GetHashCode()
        {
            return (Firstname + " " + Secondname).GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Firstname + " lastname=" + Secondname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (Firstname.CompareTo(other.Firstname) != 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            else
            {
                return Secondname.CompareTo(other.Secondname);
            }
        }
    }
}
