using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Proyecto_App_AlmaFria.MVVM.ViewModels
{
    public class AboutPageViewModel : ObservableObject
    {
        public ObservableCollection<Testimonial> Testimonials { get; set; }

        public AboutPageViewModel()
        {
            Testimonials = new ObservableCollection<Testimonial>
            {
                new Testimonial { Name = "Diego\nFernando\nSolano\nPortocarrero", Image = "https://almacenamientoalmafria.blob.core.windows.net/almafriafiles/Fernando_SP.jpg" },
                new Testimonial { Name = "Courtney\nLucero\nVaca\nHonores", Image = "https://almacenamientoalmafria.blob.core.windows.net/almafriafiles/Courtney_VH.jpg" },
                new Testimonial { Name = "Jesus\nEnrique\nAponte\nRamirez", Image = "https://almacenamientoalmafria.blob.core.windows.net/almafriafiles/Jesus_AR.jpg" },
                new Testimonial { Name = "Victor\nThomas\nLlanos\nSalirrosas", Image = "https://almacenamientoalmafria.blob.core.windows.net/almafriafiles/Victor_LS.jpg" },
                new Testimonial { Name = "Jean\nEdgardo\nTerrones\nGuarniz", Image = "https://almacenamientoalmafria.blob.core.windows.net/almafriafiles/Jean_TG.jpg" }
            };
        }
    }

    public class Testimonial
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
