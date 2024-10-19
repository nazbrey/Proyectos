using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersService.Users.Domain.Entities
{
   public class User
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Esta propiedad es autogenerada por EF

        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        // por el momento es una prueba para probar con la base de datos y despues  con el framework de flutter aunque primero  toca probarla con la app de react 
        // un futuro estara asociado a una empresa id 
        // ciudad es una tabla que no existe en la base de datos
        //public string Role { get; set; } // cuando cree la tabla rol puedo ingresarlo aca el id del rol solo prodra tener un rol 

        public User(string name, string email, string passwordHash, string lastName, string fullname, DateTime birthDate, string phone)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Fullname = fullname ?? throw new ArgumentNullException(nameof(fullname));   
            Email = email ?? throw new ArgumentNullException(nameof(email));
            PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
            BirthDate = birthDate;
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
           // Role = role ?? throw new ArgumentNullException(nameof(role));
        }
    }

}
