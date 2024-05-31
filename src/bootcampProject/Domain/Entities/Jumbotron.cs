using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Jumbotron : Entity<int>
{
    public string BackgroundImageUrl { get; set; }
    public string ButtonText { get; set; }
    public List<string> Words { get; set; }

    public Jumbotron()
    {
        Words = new List<string>();
    }

    public Jumbotron(string backgroundImageUrl, string buttonText, List<string> words)
        : this()
    {
        BackgroundImageUrl = backgroundImageUrl;
        ButtonText = buttonText;
        Words = words;
    }
}
