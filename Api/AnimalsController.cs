namespace Api;

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

public class AnimalsController
{
    [HttpGet("/animals")]
    public IEnumerable<Animal> GetAnimals()
    {
        return Startup.animals;
    }

    [HttpGet("/animals/{id}")]
    public Animal GetAnimal(int id)
    {
        return Startup.animals.FirstOrDefault(a => a.Id == id);
    }

    [HttpPost("/animals")]
    public void AddAnimal([FromBody] Animal animal)
    {
        animal.Id = Startup.nextAnimalId++;
        Startup.animals.Add(animal);
    }

    [HttpPut("/animals/{id}")]
    public void UpdateAnimal(int id, [FromBody] Animal updatedAnimal)
    {
        var index = Startup.animals.FindIndex(a => a.Id == id);
        if (index != -1)
        {
            Startup.animals[index] = updatedAnimal;
        }
    }

    [HttpDelete("/animals/{id}")]
    public void DeleteAnimal(int id)
    {
        Startup.animals.RemoveAll(a => a.Id == id);
    }
}