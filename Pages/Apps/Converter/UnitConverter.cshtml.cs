using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Codeworkhub.Pages.Apps.Converter
{
    public class UnitConverterModel : PageModel
    {
        public IActionResult OnGetConvert(double value, string from, string to, string category)
        {
            double result = 0;

            switch (category)
            {
                case "length":
                    result = ConvertLength(value, from, to);
                    break;

                case "weight":
                    result = ConvertWeight(value, from, to);
                    break;

                case "temperature":
                    result = ConvertTemperature(value, from, to);
                    break;
            }

            return Content(result.ToString("0.####"));
        }

        private double ConvertLength(double v, string f, string t)
        {
            double meters = f switch
            {
                "Meters" => v,
                "Kilometers" => v * 1000,
                "Centimeters" => v / 100,
                "Millimeters" => v / 1000,
                "Miles" => v * 1609.34,
                "Feet" => v * 0.3048,
                _ => v
            };

            return t switch
            {
                "Meters" => meters,
                "Kilometers" => meters / 1000,
                "Centimeters" => meters * 100,
                "Millimeters" => meters * 1000,
                "Miles" => meters / 1609.34,
                "Feet" => meters / 0.3048,
                _ => meters
            };
        }

        private double ConvertWeight(double v, string f, string t)
        {
            double kg = f switch
            {
                "Kilograms" => v,
                "Grams" => v / 1000,
                "Pounds" => v * 0.453592,
                _ => v
            };

            return t switch
            {
                "Kilograms" => kg,
                "Grams" => kg * 1000,
                "Pounds" => kg / 0.453592,
                _ => kg
            };
        }

        private double ConvertTemperature(double v, string f, string t)
        {
            if (f == t) return v;

            return (f, t) switch
            {
                ("Celsius", "Fahrenheit") => v * 9 / 5 + 32,
                ("Celsius", "Kelvin") => v + 273.15,
                ("Fahrenheit", "Celsius") => (v - 32) * 5 / 9,
                ("Fahrenheit", "Kelvin") => (v - 32) * 5 / 9 + 273.15,
                ("Kelvin", "Celsius") => v - 273.15,
                ("Kelvin", "Fahrenheit") => (v - 273.15) * 9 / 5 + 32,
                _ => v
            };
        }
    }
}
