using FluentAssertions;
using TagCloud.ResultModel;

namespace TagCloudTests;

public class ResultTests
{
    [Test]
    public void Ok_ShouldBeSuccessAndContainValue_WhenValueIsProvided()
    {
        var result = Result.Ok(52);

        result.IsSuccess.Should().BeTrue();
        result.GetValueOrThrow().Should().Be(52);
    }

    [Test]
    public void Fail_ShouldNotBeSuccessAndContainError_WhenErrorIsProvided()
    {
        var result = Result.Fail<int>("some error");

        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be("some error");
    }

    [Test]
    public void GetValueOrThrow_ShouldThrow_WhenFail()
    {
        var result = Result.Fail<int>("error");

        Action action = () => result.GetValueOrThrow();

        action.Should().Throw<InvalidOperationException>();
    }

    [Test]
    public void Then_ShouldTransformValue_WhenSuccess()
    {
        var result = Result.Ok(3)
            .Then(x => x * 3);

        result.IsSuccess.Should().BeTrue();
        result.GetValueOrThrow().Should().Be(9);
    }

    [Test]
    public void Then_ShouldNotCallNextAction_WhenFail()
    {
        var isCalled = false;

        var result = Result.Fail<int>("error")
            .Then(x =>
            {
                isCalled = true;
                return x * 2;
            });

        result.IsSuccess.Should().BeFalse();
        isCalled.Should().BeFalse();
    }

    [Test]
    public void Of_ShouldCatchExceptionAndReturnFail_WhenExceptionIsInside()
    {
        var result = Result.Of<int>(() => throw new Exception("error"));

        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Contain("error");
    }

    [Test]
    public void RefineError_ShouldPrefixErrorMessage()
    {
        var result = Result.Fail<int>("error")
            .RefineError("refined error");

        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be("refined error. error");
    }
}