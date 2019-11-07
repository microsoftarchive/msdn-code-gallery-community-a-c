// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandLineTest.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CmdLine.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// This is a test class for CommandLineTest and is intended to contain all CommandLineTest Unit Tests
    /// </summary>
    [TestClass]
    public class CommandLineTest
    {
        #region Public Properties

        /// <summary>
        ///   Gets or sets the test context which provides information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// The attribute with no command name should use property name.
        /// </summary>
        [TestMethod]
        public void AttributeWithNoCommandNameShouldUsePropertyName()
        {
            CommandLine.CommandEnvironment = new TestCommandEnvironment("/b1-");
            var actual = CommandLine.Parse<PropWithNoCommandName>();
            Assert.IsFalse(actual.b1);
        }

        /// <summary>
        /// The case sensitive allows upper and lower with same switch.
        /// </summary>
        [TestMethod]
        public void CaseSensitiveAllowsUpperAndLowerWithSameSwitch()
        {
            CommandLine.CommandEnvironment = new TestCommandEnvironment("/t:lower /T:UPPER /y /Y-");
            var oldValue = CommandLine.CaseSensitive;
            CommandLine.CaseSensitive = true;

            var actual = CommandLine.Parse<TypeWithUpperAndLower>();

            CommandLine.CaseSensitive = oldValue;

            Assert.AreEqual("lower", actual.Lower);
            Assert.AreEqual("UPPER", actual.Upper);
            Assert.IsTrue(actual.YLower);
            Assert.IsFalse(actual.YUpper);
        }

        /// <summary>
        /// The command line tokenizes question mark switches.
        /// </summary>
        [TestMethod]
        public void CommandLineTokenizesQuestionMarkSwitches()
        {
            var args = new[] { "/?" };

            CommandLine.CommandEnvironment = new TestCommandEnvironment(args);

            var tokens = CommandLine.Tokenize();

            foreach (var token in tokens)
            {
                this.TestContext.WriteLine("Token {0}: ", token);
            }

            Assert.AreEqual(1, CommandLine.Args.Length);
            Assert.AreEqual(1, CommandLine.GetSwitches(tokens).Count);
            Assert.AreEqual(0, CommandLine.GetParameters(tokens).Count);
            Assert.IsTrue(tokens[0].IsCommand());
            Assert.AreEqual("?", tokens[0].Command);
        }

        /// <summary>
        /// The command line tokenizes switches and parameters.
        /// </summary>
        [TestMethod]
        public void CommandLineTokenizesSwitchesAndParameters()
        {
            var args = new[]
                {
                    "C:\\Foo And Bar\\Some Long File.txt", "/1:Test", "-2:Some Quoted Arg", "/3=Arg with in it", "/Y-", "And another", "Another", "One", "Word", 
                    "Args"
                };

            CommandLine.CommandEnvironment = new TestCommandEnvironment(args);

            var tokens = CommandLine.Tokenize();

            foreach (var token in tokens)
            {
                this.TestContext.WriteLine("Token {0}: ", token);
            }

            Assert.AreEqual(10, CommandLine.Args.Length);
            Assert.AreEqual(4, CommandLine.GetSwitches(tokens).Count);
            Assert.AreEqual(6, CommandLine.GetParameters(tokens).Count);
            Assert.IsTrue(tokens[0].IsParameter());
            Assert.IsTrue(tokens[1].IsCommand());
            Assert.IsTrue(tokens[2].IsCommand());
            Assert.IsTrue(tokens[3].IsCommand());
            Assert.IsTrue(tokens[4].IsCommand());
            Assert.IsTrue(tokens[5].IsParameter());
            Assert.IsTrue(tokens[6].IsParameter());
            Assert.IsTrue(tokens[7].IsParameter());
            Assert.IsTrue(tokens[8].IsParameter());
            Assert.IsTrue(tokens[9].IsParameter());
            for (var i = 0; i < args.Length; i++)
            {
                Assert.AreEqual(args[i], tokens[i].Token);
            }
        }

        /// <summary>
        /// Verifies that you can use alternate seperators
        /// </summary>
        [TestMethod]
        public void CommandLineTokenizesWithAlternateSwitchChars()
        {
            var args = new[]
                {
                    "C:\\Foo And Bar\\Some Long File.txt", "~1|Test", "~2|Some Quoted Arg", "~3|Arg with in it", "_Y-", "And another", "Another", "One", "Word", 
                    "Args"
                };

            CommandLine.CommandEnvironment = new TestCommandEnvironment(args);

            // Save the seperators since they are static members
            var oldSep = CommandLine.CommandSeparators;
            var oldValueSep = CommandLine.ValueSeparators;

            CommandLine.CommandSeparators = new List<string> { "~", "_" };
            CommandLine.ValueSeparators = new List<string> { "|" };

            this.TestContext.WriteLine(CommandLine.Text);

            var tokens = CommandLine.Tokenize();

            // Restore the seperators
            CommandLine.CommandSeparators = oldSep;
            CommandLine.ValueSeparators = oldValueSep;

            foreach (var token in tokens)
            {
                this.TestContext.WriteLine("Token {0}: ", token);
            }

            Assert.AreEqual(10, CommandLine.Args.Length);
            Assert.AreEqual(4, CommandLine.GetSwitches(tokens).Count);
            Assert.AreEqual(6, CommandLine.GetParameters(tokens).Count);
            Assert.IsTrue(tokens[0].IsParameter());
            Assert.IsTrue(tokens[1].IsCommand());
            Assert.IsTrue(tokens[2].IsCommand());
            Assert.IsTrue(tokens[3].IsCommand());
            Assert.IsTrue(tokens[4].IsCommand());
            Assert.IsTrue(tokens[5].IsParameter());
            Assert.IsTrue(tokens[6].IsParameter());
            Assert.IsTrue(tokens[7].IsParameter());
            Assert.IsTrue(tokens[8].IsParameter());
            Assert.IsTrue(tokens[9].IsParameter());
            for (var i = 0; i < args.Length; i++)
            {
                Assert.AreEqual(args[i], tokens[i].Token);
            }
        }

        /// <summary>
        /// The customer test.
        /// </summary>
        [TestMethod]
        public void CustomerTest()
        {
            const string Cmdline = "x.x /A y.y /D";
            CommandLine.CommandEnvironment = new TestCommandEnvironment(Cmdline);

            var tokens = CommandLine.Tokenize();

            foreach (var token in tokens)
            {
                this.TestContext.WriteLine("Token {0}: ", token);
            }

            Assert.AreEqual(4, CommandLine.Args.Length);
            Assert.AreEqual(2, CommandLine.GetSwitches(tokens).Count);
            Assert.AreEqual(2, CommandLine.GetParameters(tokens).Count);
            Assert.IsTrue(tokens[0].IsParameter());
            Assert.IsTrue(tokens[1].IsCommand());
            Assert.IsTrue(tokens[2].IsParameter());
            Assert.IsTrue(tokens[3].IsCommand());
        }

        /// <summary>
        /// The default args are applied.
        /// </summary>
        [TestMethod]
        public void DefaultArgsAreApplied()
        {
            CommandLine.CommandEnvironment = new TestCommandEnvironment("/n:123");
            var target = CommandLine.Parse<TestArgs>();

            Assert.IsTrue(target.BoolT);
            Assert.IsFalse(target.BoolY);
            Assert.AreEqual(TestArgs.StringArgDefault, target.StringArg);
        }

        /// <summary>
        /// The duplicate args should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CommandLineArgumentInvalidException))]
        public void DuplicateArgsShouldThrow()
        {
            CommandLine.CommandEnvironment = new TestCommandEnvironment("/N:123 /N:345");
            CommandLine.Parse<TestArgs>();
        }

        /// <summary>
        /// The duplicate args with list should not throw.
        /// </summary>
        [TestMethod]
        public void DuplicateArgsWithListShouldNotThrow()
        {
            CommandLine.CommandEnvironment = new TestCommandEnvironment("/N:123 /N:345");
            var actual = CommandLine.Parse<TestArgsWithList>();
            Assert.AreEqual(2, actual.NList.Count);
            Assert.AreEqual("123", actual.NList[0]);
            Assert.AreEqual("345", actual.NList[1]);
        }

        /// <summary>
        /// The embedded separators do not count as switch.
        /// </summary>
        [TestMethod]
        public void EmbeddedSeparatorsDoNotCountAsSwitch()
        {
            var args = new[] { "/S:Value/With:Separators", "/Y-", "/t", "/N:123" };

            CommandLine.CommandEnvironment = new TestCommandEnvironment(args);

            var actual = CommandLine.Parse<TestArgs>();

            Assert.AreEqual("Value/With:Separators", actual.StringArg);
            Assert.IsTrue(actual.BoolT);
            Assert.IsFalse(actual.BoolY);
        }

        /// <summary>
        /// The missing required position arg should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CommandLineRequiredArgumentMissingException))]
        public void MissingRequiredPositionArgShouldThrow()
        {
            CommandLine.CommandEnvironment = new TestCommandEnvironment();
            CommandLine.Parse<ThreeRequiredPositionArgs>();
        }

        /// <summary>
        /// The missing required switch arg should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CommandLineRequiredArgumentMissingException))]
        public void MissingRequiredSwitchArgShouldThrow()
        {
            CommandLine.CommandEnvironment = new TestCommandEnvironment();
            CommandLine.Parse<TestArgs>();
        }

        /// <summary>
        /// The no matching property should throw.
        /// </summary>
        [TestMethod]
        public void NoMatchingPropertyShouldThrow()
        {
            var args = new[] { "/?" };

            CommandLine.CommandEnvironment = new TestCommandEnvironment(args);

            try
            {
                CommandLine.Parse<TestArgs>();
                Assert.Fail("Parse did not throw an exception");
            }
            catch (CommandLineArgumentInvalidException exception)
            {
                Assert.IsNotNull(exception.ArgumentHelp);
                Assert.AreEqual(4, exception.ArgumentHelp.ValidArguments.Count());
                foreach (var validArgument in exception.ArgumentHelp.ValidArguments)
                {
                    this.TestContext.WriteLine(validArgument.ToString());
                }
            }
        }

        /// <summary>
        /// The no matching property with inferred should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CommandLineArgumentInvalidException))]
        public void NoMatchingPropertyWithInferredShouldThrow()
        {
            var args = new[] { "/NoMatch" };

            CommandLine.CommandEnvironment = new TestCommandEnvironment(args);

            CommandLine.Parse<InferredTestArgs>();
        }

        /// <summary>
        /// The parse does not throw when null command line.
        /// </summary>
        [TestMethod]
        public void ParseDoesNotThrowWhenNullCommandLine()
        {
            CommandLine.CommandEnvironment = new TestCommandEnvironment();
            CommandLine.Parse<object>();
        }

        /// <summary>
        /// Verifies positional args work
        /// </summary>
        [TestMethod]
        public void PositionalArgsAreApplied()
        {
            var args = new[]
                {
                    @"D:\Documents and Settings\MY.USERNAME\My Documents\*", @"E:\MYBACKUP\My Documents\", "/A", @"/EXCLUDE:SomeQuoted String", "/I", 
                    "/D:7-8-2011"
                };

            CommandLine.CommandEnvironment = new TestCommandEnvironment(args);
            var xcopyCommand = CommandLine.Parse<XCopyCommandArgs>();

            Assert.IsNotNull(xcopyCommand);
            Assert.AreEqual(args[0], xcopyCommand.Source);
            Assert.AreEqual(args[1], xcopyCommand.Destination);
            Assert.AreEqual("SomeQuoted String", xcopyCommand.ExcludeFiles);
            Assert.IsTrue(xcopyCommand.ArchivedBit);
            Assert.IsTrue(xcopyCommand.InferDirectory);
            Assert.AreEqual(new DateTime(2011, 7, 8), xcopyCommand.ChangedAfterDate);
        }

        /// <summary>
        /// The try parse test.
        /// </summary>
        [TestMethod]
        public void TryParseFalseTest()
        {
            CommandLine.CommandEnvironment = new TestCommandEnvironment();

            BadPositionArgMissingTwo options;
            Exception exception;

            Assert.IsFalse(CommandLine.TryParse(out options, out exception));
            Assert.IsNotNull(exception);
            Assert.IsNull(options);
        }

        /// <summary>
        /// The try parse success test.
        /// </summary>
        [TestMethod]
        public void TryParseSuccessTest()
        {
            var args = new[]
                {
                    @"D:\Documents and Settings\MY.USERNAME\My Documents\*", @"E:\MYBACKUP\My Documents\", "/A", @"/EXCLUDE:SomeQuoted String", "/I", 
                    "/D:7-8-2011"
                };

            CommandLine.CommandEnvironment = new TestCommandEnvironment(args);
            XCopyCommandArgs xcopyCommand;
            Exception exception;

            Assert.IsTrue(CommandLine.TryParse(out xcopyCommand, out exception));

            Assert.IsNotNull(xcopyCommand);
            Assert.AreEqual(args[0], xcopyCommand.Source);
            Assert.AreEqual(args[1], xcopyCommand.Destination);
            Assert.AreEqual("SomeQuoted String", xcopyCommand.ExcludeFiles);
            Assert.IsTrue(xcopyCommand.ArchivedBit);
            Assert.IsTrue(xcopyCommand.InferDirectory);
            Assert.AreEqual(new DateTime(2011, 7, 8), xcopyCommand.ChangedAfterDate);
        }

        /// <summary>
        /// The two props with same switch should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CommandLineException))]
        public void TwoPropsWithSameSwitchShouldThrow()
        {
            CommandLine.CommandEnvironment = new TestCommandEnvironment();
            CommandLine.Parse<TwoPropsWithSameSwitch>();
        }

        /// <summary>
        /// The when bad parameter index should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CustomAttributeFormatException))]
        public void WhenBadParameterIndexShouldThrow()
        {
            CommandLine.CommandEnvironment = new TestCommandEnvironment();
            CommandLine.Parse<TypeWithBadParamIndex>();
        }

        /// <summary>
        /// The when duplicate position should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CommandLineException))]
        public void WhenDuplicatePositionShouldThrow()
        {
            CommandLine.CommandEnvironment = new TestCommandEnvironment();
            CommandLine.Parse<TypeWithDuplicateParamIndex>();
        }

        /// <summary>
        /// The when no attributes parse will use property names.
        /// </summary>
        [TestMethod]
        public void WhenNoAttributesParseWillUsePropertyNames()
        {
            var args = new[] { "/StringArg:Value/With:Separators", "/BoolY-", "/BoolT", "/Date:12-01-2011", "/Number:23" };

            CommandLine.CommandEnvironment = new TestCommandEnvironment(args);

            var actual = CommandLine.Parse<InferredTestArgs>();

            Assert.AreEqual("Value/With:Separators", actual.StringArg);
            Assert.IsTrue(actual.BoolT);
            Assert.IsFalse(actual.BoolY);
            Assert.AreEqual(new DateTime(2011, 12, 1), actual.Date);
            Assert.AreEqual(23, actual.Number);
        }

        /// <summary>
        /// The when no position one should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CommandLineException))]
        public void WhenNoPositionOneShouldThrow()
        {
            CommandLine.CommandEnvironment = new TestCommandEnvironment();
            CommandLine.Parse<BadPositionArgNoOne>();
        }

        /// <summary>
        /// The when no position two should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CommandLineException))]
        public void WhenNoPositionTwoShouldThrow()
        {
            CommandLine.CommandEnvironment = new TestCommandEnvironment();
            CommandLine.Parse<BadPositionArgMissingTwo>();
        }

        #endregion
    }
}