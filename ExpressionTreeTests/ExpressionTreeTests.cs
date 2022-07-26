using NUnit.Framework;

namespace ExpressionTreeTests;

[TestFixture]
public class ExpressionTreeTests
{
    [SetUp]
    public void Setup()
    {
    }

    public void TreeTest()
    {
        /*
         * I stopped after implementing the tree. I didn't write any tests.
         * The problem is I don't even know what to write. How should I test that
         * the tree is valid? How should I test this?
         *
         * One possible way to do this is to do a traversal and try to match
         * the output of parser with the output of the tree traversal method.
         * The order of the operator and operands should match for both lists.
         */
        Assert.Pass();
    }
}