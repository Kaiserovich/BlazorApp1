namespace BlazorApp1.Models
{
    public class AppStyle
    {
        public string Color { get; set; } = "green";
        public string Size { get; set; } = "65px";
        public List<string> WitcherWords { get; set; } = new List<string>()
        {
            new string("Видишь ли, эльфийская красота- она как молодое из Боклера. А я как-то больше по водке"),
            new string("Ты чудесно пахнешь на этих похоронах"),
            new string("Хочешь меня нахер послать? Милости просим, давай... Я тебя тоже пошлю... ну и чоо?")
        };
    }
}
