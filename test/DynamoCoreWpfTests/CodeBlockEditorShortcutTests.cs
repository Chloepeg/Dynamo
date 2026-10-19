using System.Windows.Input;
using Dynamo.UI.Controls;
using NUnit.Framework;

namespace DynamoCoreWpfTests
{
    [TestFixture]
    [Category("UnitTests")]
    public class CodeBlockEditorShortcutTests
    {
        [Test]
        [TestCase(Key.L, ModifierKeys.Control)]
        [TestCase(Key.P, ModifierKeys.Control)]
        [TestCase(Key.B, ModifierKeys.Control)]
        [TestCase(Key.D0, ModifierKeys.Control)]
        [TestCase(Key.OemPlus, ModifierKeys.Control)]
        [TestCase(Key.OemMinus, ModifierKeys.Control)]
        [TestCase(Key.Add, ModifierKeys.Control)]
        [TestCase(Key.Subtract, ModifierKeys.Control)]
        [TestCase(Key.Left, ModifierKeys.Control | ModifierKeys.Alt)]
        [TestCase(Key.Right, ModifierKeys.Control | ModifierKeys.Alt)]
        [TestCase(Key.Up, ModifierKeys.Control | ModifierKeys.Alt)]
        [TestCase(Key.Down, ModifierKeys.Control | ModifierKeys.Alt)]
        public void WhenGraphNavigationShortcutThenItIsBlockedWhileEditingCodeBlock(
            Key key, ModifierKeys modifiers)
        {
            Assert.IsTrue(CodeBlockEditor.IsBlockedGraphShortcut(key, modifiers));
        }

        [Test]
        [TestCase(Key.S, ModifierKeys.Control)]
        [TestCase(Key.Z, ModifierKeys.Control)]
        [TestCase(Key.C, ModifierKeys.Control)]
        [TestCase(Key.V, ModifierKeys.Control)]
        [TestCase(Key.A, ModifierKeys.None)]
        [TestCase(Key.L, ModifierKeys.Control | ModifierKeys.Shift)]
        public void WhenNonBlockedShortcutThenItIsNotBlockedWhileEditingCodeBlock(
            Key key, ModifierKeys modifiers)
        {
            Assert.IsFalse(CodeBlockEditor.IsBlockedGraphShortcut(key, modifiers));
        }
    }
}
