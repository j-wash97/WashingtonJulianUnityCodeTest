using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WashingtonJulianUnityCodeTest.Models;

namespace WashingtonJulianUnityCodeTest.Controllers
{
    public class ProjectController : Controller
    {
        //A reference to the application's database connection
        private ProjectDBContext db = new ProjectDBContext();

        // GET: Project
        public ActionResult Index()
        {
            //If one doesn't exist, a collection of all the project's the application can randomly deliver to the user is created
            if (Session["projects"] == null)
                Session["projects"] = new List<Info>();

            //When there are no projects left available in the list, all available projects are added back to the list
            if (((List<Info>)Session["projects"]).Count <= 0)
                Session["projects"] = db.Projects.ToList();


            //A random project is selected and removed from the list
            int projIndex = new Random().Next(((List<Info>)Session["projects"]).Count);
            Info projInfo = ((List<Info>)Session["projects"]).ElementAt(projIndex);
            ((List<Info>)Session["projects"]).RemoveAt(projIndex);

            //The data from the selected project is gathered and sent to the view
            Project project = new Project
            {
                ProjInfo = projInfo,
                //Any article section with a matching project ID is added to the project and ordered by ID
                Sections = db.Sections.Where(x => x.ProjID == projInfo.ID).OrderBy(x => x.ID).ToArray(),
                //Any piece of content a matching project ID is added to the project
                Contents = db.Contents.Where(x => x.ProjID == projInfo.ID).ToArray()
            };
            return View(project);
        }
    }
}