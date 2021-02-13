using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisnessLogicDll.Models;
using TamagotchiWebAPI.DataTransferObjects;
using System.Net.Http;




namespace TamagotchiWebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class TamagotchiController : ControllerBase
    {
        TamagotchiContext context;

        public TamagotchiController(TamagotchiContext context)
        {
            this.context = context;
        }

        [Route("Login")]
        [HttpGet]
        public PlayerDTO Login([FromQuery] string username, [FromQuery] string pass)
        {
            Player p = context.Login(username, pass);

            //Check user name and password
            if (p != null)
            {
                PlayerDTO pDTO = new PlayerDTO(p);

                HttpContext.Session.SetObject("player", pDTO);

                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return pDTO;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }

        [Route("LogOut")]
        [HttpGet]
        public void LogOut()
        {
            PlayerDTO pDTO = HttpContext.Session.GetObject<PlayerDTO>("player");
            if (pDTO != null)
            {
                
                HttpContext.Session.Clear();
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
            }
        }
        [Route("DoesExist")]
        [HttpGet]
        public bool DoesExist([FromQuery] string uName, [FromQuery] string email)
        {
            Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            return context.DoesExist(uName, email);
        }

        [Route("CreateNewAnimal")]
        [HttpGet]
        public AnimalDTO CreateNewAnimal([FromQuery] string name)
        {
            PlayerDTO pDTO = HttpContext.Session.GetObject<PlayerDTO>("player");
            if (pDTO != null)
            {
                Animal a = Animal.CreateAnimal(name, pDTO.PlayerId);
                context.AddAnimal(a);
                if (GetActiveAnimal() != null)
                {
                    context.KillActiveAnimal(pDTO.PlayerId);
                }
                context.SetActiveAnimal(a, pDTO.PlayerId);
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return new AnimalDTO(a);
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;

            }
        }

        [Route("GetActiveAnimal")]
        [HttpGet]
        public AnimalDTO GetActiveAnimal()
        {
            PlayerDTO pDTO = HttpContext.Session.GetObject<PlayerDTO>("player");
            if (pDTO != null)
            {
                int id = pDTO.PlayerId;
                Animal a = context.GetActiveAnimal(id);
                if (a == null)
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                    return null;
                }
                    
                AnimalDTO aDTO = new AnimalDTO(a);
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return aDTO;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }

        [Route("SignUp")]
        [HttpPost]
        public bool SignUp([FromBody] PlayerDTO player)
        {
            PlayerDTO pDTO = HttpContext.Session.GetObject<PlayerDTO>("player");

            if (pDTO == null)
            {
                Player p = new Player()
                {
                    PlayerId = player.PlayerId,
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    Email = player.Email,
                    Gender = player.Gender,
                    Username = player.Username,
                    PWord = player.PWord,
                    DateOfBirth = player.DateOfBirth,
                    ActiveAnimal = player.ActiveAnimal
                };
                context.AddPlayer(p);
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return true;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return false;
            }

        }
        [Route("CheckPassword")]
        [HttpGet]
        public bool CheckPassword([FromQuery] string pass)
        {
            PlayerDTO pDTO = HttpContext.Session.GetObject<PlayerDTO>("player");
            if (pDTO != null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return pDTO.PWord == pass;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return false;
            }

        }
        [Route("SetPassword")]
        [HttpGet]
        public bool SetPassword([FromQuery] string pass)
        {
            PlayerDTO pDTO = HttpContext.Session.GetObject<PlayerDTO>("player");
            if (pDTO != null)
            {
                Player p = context.Login(pDTO.Username, pDTO.PWord);
                p.PWord = pass;
                context.SaveChanges();
                pDTO.PWord = pass;
                HttpContext.Session.SetObject("player", pDTO);
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return true;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return false;
            }
        }

        




    } 
}


