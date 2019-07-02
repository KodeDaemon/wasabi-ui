using Microsoft.Build.Framework;
using Moq;
using NUnit.Framework;

namespace WasabiUI.Forms.Build.Tools.Tests
{
    [TestFixture]
    public class VariableConstantsTests
    {
        [Test]
        public void BasicTest()
        {
            var result = Set(values:new[] {"XXX"});

            if(!result)
                Assert.Fail();

            var w = Get();

            Assert.AreEqual(w, "XXX");

            var clear = Set();

            if(!clear)
                Assert.Fail();

            w = Get();

            Assert.IsNull(w);
        }

        [Test]
        public void TargetAndVariableTest()
        {
            const string variable = "SOME_VARIABLE";

            const string target = "Process";

            const string value = "SOME_VALUE";

            var result = Set(variable:variable, values:new[] {value}, target:target);

            if(!result)
                Assert.Fail();

            var w = Get(variable:variable, target:target);

            Assert.AreEqual(w, value);

            var clear = Set(variable:variable, target:target);

            if(!clear)
                Assert.Fail();

            w = Get(variable:variable, target:target);

            Assert.IsNull(w);
        }

        [Test]
        public void MultipleValuesTest()
        {
            const string variable = "MultipleValues";

            const string target = "User";

            var result = Set(variable: variable, values: new[] {"Var1", "Var2", "Var3"}, target: target);

            if(!result)
                Assert.Fail();

            var w = Get(variable: variable, target: target);

            Assert.AreEqual(w, "Var1;Var2;Var3");

            var clear = Set();

            if(!clear)
                Assert.Fail();

            w = Get();

            Assert.IsNull(w);
        }

        [Test]
        public void OverwriteTest()
        {
            var result = Set(values:new[] {"VALUE1"});

            if(!result)
                Assert.Fail();

            result = Set(values:new[] {"VALUE2"});

            if(!result)
                Assert.Fail();

            var w = Get();

            Assert.AreEqual(w, "VALUE2");

            var clear = Set();

            if(!clear)
                Assert.Fail();

            w = Get();

            Assert.IsNull(w);
        }

        [Test]
        public void EmptyStringValueTest()
        {
            var result = Set(values:new[] {""});

            if(!result)
                Assert.Fail();

            var w = Get();

            Assert.AreEqual(w, null);

            var clear = Set();

            if(!clear)
                Assert.Fail();

            w = Get();

            Assert.IsNull(w);
        }

        private bool Set(string variable = "", string[] values = null, string target = "")
        {
            var setVar = new VariableConstants
            {
                TaskAction = "Set", 
                BuildEngine = new Mock<IBuildEngine>().Object,
                Value = values
            };

            if (!string.IsNullOrEmpty(variable))
                setVar.Variable = variable;

            if (!string.IsNullOrEmpty(target))
                setVar.Target = target;

            return setVar.Execute();
        }

        private string Get(string variable = "", string target = "")
        {
            var getVar = new VariableConstants
            {
                TaskAction = "Get", 
                BuildEngine = new Mock<IBuildEngine>().Object
            };

            if (!string.IsNullOrEmpty(variable))
                getVar.Variable = variable;

            if (!string.IsNullOrEmpty(target))
                getVar.Target = target;

            getVar.Execute();

            return getVar.Value == null ? null : string.Join(";", getVar.Value);
        }
    }
}
