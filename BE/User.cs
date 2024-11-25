using HiperMegaRed.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.BE
{
    public class User : AbstractGuidEntity, IUser
    {
        public User()
        {

        }
        public User(string username, string password)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            _permisos = new List<Componente>();
        }

        //public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? LastLogin { get; set; }
        public int FailCount { get; set; } = 0;
        public string Language { get; set; }
        public bool Expired { get; set; } = false;
        public string Name { get; set; }
        public string Lastname { get; set; } = string.Empty;
        public string Mail { get; set; }
        public string Phone { get; set; }
        public decimal DNI { get; set; }
        public int DVHorizontal { get; set; }

        List<Componente> _permisos;

        public List<Componente> Permisos
        {
            get
            {
                return _permisos;
            }
            set
            {
                _permisos = value;
            }
        }

        public override string ToString()
        {
            return Username;
        }
    }
}
