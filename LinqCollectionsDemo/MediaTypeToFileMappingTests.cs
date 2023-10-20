using static LinqCollectionsDemo.MediaTypeToFileName;

namespace LinqCollectionsDemo;

public class MediaTypeToFileMappingTests
{
    [Test]
    public void MediaTypeToFileImperative()
    {
        Assert.Multiple(() =>
        {
            Assert.That(GetFileNameImperativeSwitchStatement(Word), Is.EqualTo(MsWordFileName));
            Assert.That(GetFileNameImperativeMultipleIf(Word), Is.EqualTo(MsWordFileName));
        });
    }

    [Test]
    public void MediaTypeToFileExpressive()
    {
        Assert.Multiple(() =>
        {
            Assert.That(GetFileNameDeclarative(Word), Is.EqualTo(MsWordFileName));
            Assert.That(GetFileNameSwitchExpression(Word), Is.EqualTo(MsWordFileName));
        });
    }

    [Test]
    public void MediaTypeToFileExpressiveNoDefault()
    {
        Assert.Throws<KeyNotFoundException>(() => { _ = GetFileNameDeclarativeNoDefault("bogus"); });
    }
}