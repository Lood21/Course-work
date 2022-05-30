#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvacUa.Models;

namespace EvacUa.Controllers
{
    public class VehicleController : Controller
    {
        private readonly VehicleDb _context;


        public VehicleController(VehicleDb context)
        {
            _context = context;
        }
    }
}
