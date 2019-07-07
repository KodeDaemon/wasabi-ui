using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace WasabiUI.Forms.Components
{
    public class StyleMapper
    {
        private const string Px = "px";

        private string _class;
        private bool _dirty = true;

        public string Style
        {
            get
            {
                if (_dirty)
                {
                    _class = string.Join(";", map.Where(i => i.Value.Condition()).Select(i => $"{i.Key()}: {i.Value.Value}"));
                }

                return _class;
            }
        }


        private Dictionary<Func<string>, StyleHolder> map = new Dictionary<Func<string>, StyleHolder>();


        public void MakeDirty()
        {
            _dirty = true;
        }

        public StyleMapper Add(string name, string value)
        {
            map.Add(() => name, new StyleHolder{Condition = () => true, Value = () => value});
            return this;
        }


        public StyleMapper Get(Func<string> funcName, Func<string> funcValue)
        {
            map.Add(funcName, new StyleHolder { Condition = () => true, Value = funcValue });
            return this;
        }

        public StyleMapper GetIf(Func<string> funcName, Func<string> funcValue, Func<bool> funcCondition)
        {
            map.Add(funcName, new StyleHolder { Condition = funcCondition, Value = funcValue});
            return this;
        }

        public StyleMapper If(string name, string value, Func<bool> func)
        {
            map.Add(() => name, new StyleHolder{Condition = func, Value = () => value});
            return this;
        }

        public StyleMapper Add(string propertyName, Thickness thickness)
        {
            var (left, top, right, bottom) = thickness;
            switch (propertyName)
            {
                case "margin":
                    map[() => "margin-left"] = new StyleHolder{Condition = () => true, Value = () => $"{left}{Px}"};
                    map[() => "margin-top"] = new StyleHolder { Condition = () => true, Value = () => $"{top}{Px}" };
                    map[() => "margin-right"] = new StyleHolder { Condition = () => true, Value = () => $"{right}{Px}" };
                    map[() => "margin-bottom"] = new StyleHolder { Condition = () => true, Value = () => $"{bottom}{Px}" };
                    break;
                default:
                    throw new ArgumentException("Style property is not handled.", nameof(propertyName));
            }

            return this;
        }
    }

    public class StyleHolder
    {
        public Func<bool> Condition { get; set; }

        public Func<string> Value { get; set; }
    }
}
