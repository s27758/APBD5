namespace Api;

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

public class VisitsController
{
    [HttpGet("/visits")]
    public IEnumerable<Visit> GetVisits()
    {
        return Startup.visits;
    }

    [HttpGet("/visits/{animalId}")]
    public IEnumerable<Visit> GetVisitsForAnimal(int animalId)
    {
        return Startup.visits.Where(v => v.AnimalId == animalId);
    }

    [HttpPost("/visits")]
    public void AddVisit([FromBody] Visit visit)
    {
        visit.Id = Startup.nextVisitId++;
        Startup.visits.Add(visit);
    }
}