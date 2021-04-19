using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdcModel.DbModel.SecurityModule
{
    public class UserDbModel: DbModelBase
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string  lastName;

        public string  LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private string document;
        public string Document
        {
            get { return document; }
            set { document = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string passwordUser;
        public string PasswordUser
        {
            get { return passwordUser; }
            set { passwordUser = value; }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private int cityId;
        public int CityId
        {
            get { return cityId; }
            set { cityId = value; }
        }

        private bool removed;

        public bool Removed
        {
            get { return removed; }
            set { removed = value; }
        }


        private DateTime removedDate;

        public DateTime RemovedDate
        {
            get { return removedDate; }
            set { removedDate = value; }
        }

        private DateTime createDate;

        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }

        

        private int removedUserId;

        public int RemovedUserId
        {
            get { return removedUserId; }
            set { removedUserId = value; }
        }

        private int createUserId;

        public int CreateUserId
        {
            get { return createUserId; }
            set { createUserId = value; }
        }

        private int updateUserId;

        public int UpdateUserId
        {
            get { return updateUserId; }
            set { updateUserId = value; }
        }

        

        private IEnumerable<RoleDbModel> roles;

        public IEnumerable<RoleDbModel> Roles
        {
            get { return roles; }
            set { roles = value; }
        }

        private string token;

        public string Token
        {
            get { return token; }
            set { token = value; }
        }


    }
}
