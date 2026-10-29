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
        [TestCase(Key.I, ModifierKeys.Control)]
        [TestCase(Key.O, ModifierKeys.Control)]
        [TestCase(Key.N, ModifierKeys.Control)]
        [TestCase(Key.T, ModifierKeys.Control)]
        [TestCase(Key.W, ModifierKeys.Control)]
        [TestCase(Key.K, ModifierKeys.Control)]
        [TestCase(Key.D0, ModifierKeys.Control)]
        [TestCase(Key.OemPlus, ModifierKeys.Control)]
        [TestCase(Key.OemMinus, ModifierKeys.Control)]
        [TestCase(Key.Add, ModifierKeys.Control)]
        [TestCase(Key.Subtract, ModifierKeys.Control)]
        [TestCase(Key.Left, ModifierKeys.Control | ModifierKeys.Alt)]
        [TestCase(Key.Right, ModifierKeys.Control | ModifierKeys.Alt)]
        [TestCase(Key.Up, ModifierKeys.Control | ModifierKeys.Alt)]
        [TestCase(Key.Down, ModifierKeys.Control | ModifierKeys.Alt)]
        [TestCase(Key.F5, ModifierKeys.None)]
        [TestCase(Key.F5, ModifierKeys.Shift)]
        [TestCase(Key.S, ModifierKeys.Control | ModifierKeys.Shift)]
        [TestCase(Key.I, ModifierKeys.Control | ModifierKeys.Shift)]
        [TestCase(Key.N, ModifierKeys.Control | ModifierKeys.Shift)]
        [TestCase(Key.Up, ModifierKeys.Control | ModifierKeys.Shift)]
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
        [TestCase(Key.Left, ModifierKeys.None)]
        [TestCase(Key.Right, ModifierKeys.None)]
        public void WhenNonBlockedShortcutThenItIsNotBlockedWhileEditingCodeBlock(
            Key key, ModifierKeys modifiers)
        {
            Assert.IsFalse(CodeBlockEditor.IsBlockedGraphShortcut(key, modifiers));
        }

        [Test]
        public void WhenSelectionExistsAndLeftArrowThenCaretCollapsesToSelectionStart()
        {
            Assert.AreEqual(3, CodeCompletionEditor.GetSelectionCollapseCaretOffset(
                selectionStart: 3, selectionLength: 5, Key.Left, ModifierKeys.None));
        }

        [Test]
        public void WhenSelectionExistsAndRightArrowThenCaretCollapsesToSelectionEnd()
        {
            Assert.AreEqual(8, CodeCompletionEditor.GetSelectionCollapseCaretOffset(
                selectionStart: 3, selectionLength: 5, Key.Right, ModifierKeys.None));
        }

        [Test]
        [TestCase(Key.Left, ModifierKeys.Shift)]
        [TestCase(Key.Right, ModifierKeys.Control)]
        [TestCase(Key.Up, ModifierKeys.None)]
        public void WhenNoCollapseNeededThenSelectionArrowHelperReturnsNull(
            Key key, ModifierKeys modifiers)
        {
            Assert.IsNull(CodeCompletionEditor.GetSelectionCollapseCaretOffset(
                selectionStart: 3, selectionLength: 5, key, modifiers));
        }

        [Test]
        public void WhenNoSelectionThenSelectionArrowHelperReturnsNull()
        {
            Assert.IsNull(CodeCompletionEditor.GetSelectionCollapseCaretOffset(
                selectionStart: 3, selectionLength: 0, Key.Left, ModifierKeys.None));
        }
    }
}
