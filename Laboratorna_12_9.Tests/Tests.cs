namespace Laboratorna_12_9.Tests;

[TestFixture]
public class Tests
{
    [Test]
    public void TestFindMinPostfix()
    {
        // Arrange
        BinaryTree tree = new BinaryTree();
        tree.AddNode(9);
        tree.AddNode(8);
        tree.AddNode(7);
        tree.AddNode(5);
        tree.AddNode(4);
        tree.AddNode(3);
        tree.AddNode(2);

        // Act
        Node minNode = tree.FindMinPostfix();

        // Assert
        Assert.AreEqual(2, minNode.info);
    }
}