using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TicketFinalSys.Models
{

    

    public class Ticket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //generate automatically
        public int ID { get; set; }                           //ID database field (key)

        [Required]                                             //required field 
        [DisplayName("First Name")]                             //Display in model view as First Name 
        public string FirstName { get; set; }

        [Required]                            //require field 
        [DisplayName("Last Name")]               //Display in model view as First Name 
        public string LastName { get; set; }

        [Required]  //required field 
        [DisplayName("Request Date")]    //Display in model view as First Name 
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]  //format the date as day/month/year
        public DateTime RequestDate { get;  set; }
        
        [Required]   //required field 
        [DisplayName("Request Description")]   //Display in model view as Request Description
        public string RequestDesc { get; set; }

        [DisplayName("Tech Assigned")]      //Display in model view as Tech Assigned 
        public string TechAssigned { get; set; }

        [DisplayName("Completion Date")]     //Display in model view as Completion Date 
        public DateTime? CompletionDate { get; set; }

        [Required]   //required field 
        public string  Note { get; set; }

        [Required]  //reuired field 
        public string Status { get; set; }

    }

    
}