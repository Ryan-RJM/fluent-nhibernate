using FluentNHibernate.MappingModel;
using FluentNHibernate.Testing.DomainModel.Mapping;
using NUnit.Framework;

namespace FluentNHibernate.Testing.FluentInterfaceTests
{
    [TestFixture]
    public class OneToOneMutablePropertyModelGenerationTests : BaseModelFixture
    {
        [Test]
        public void AccessShouldSetModelAccessPropertyToValue()
        {
            OneToOne()
                .Mapping(m => m.Access.AsField())
                .ModelShouldMatch(x => x.Access.ShouldEqual("field"));
        }

        [Test]
        public void ShouldSetModelClassPropertyToValue()
        {
            OneToOne()
                .Mapping(m => {})
                .ModelShouldMatch(x => x.Class.ShouldEqual(new TypeReference(typeof(PropertyReferenceTarget))));
        }

        [Test]
        public void CascadeShouldSetModelCascadePropertyToTrue()
        {
            OneToOne()
                .Mapping(m => m.Constrained())
                .ModelShouldMatch(x => x.Constrained.ShouldBeTrue());
        }

        [Test]
        public void NotCascadeShouldSetModelCascadePropertyToFalse()
        {
            OneToOne()
                .Mapping(m => m.Not.Constrained())
                .ModelShouldMatch(x => x.Constrained.ShouldBeFalse());
        }

        [Test]
        public void FetchShouldSetModelFetchPropertyToValue()
        {
            OneToOne()
                .Mapping(m => m.Fetch.Select())
                .ModelShouldMatch(x => x.Fetch.ShouldEqual("select"));
        }

        [Test]
        public void ForeignKeyShouldSetModelForeignKeyPropertyToValue()
        {
            OneToOne()
                .Mapping(m => m.ForeignKey("fk"))
                .ModelShouldMatch(x => x.ForeignKey.ShouldEqual("fk"));
        }

        [Test]
        public void LazyLoadShouldSetModelLazyLoadPropertyToTrue()
        {
            OneToOne()
                .Mapping(m => m.LazyLoad())
                .ModelShouldMatch(x => x.Lazy.ShouldEqual(Laziness.True));
        }

        [Test]
        public void NotLazyLoadShouldSetModelLazyLoadPropertyToFalse()
        {
            OneToOne()
                .Mapping(m => m.Not.LazyLoad())
                .ModelShouldMatch(x => x.Lazy.ShouldEqual(Laziness.False));
        }

        [Test]
        public void ShouldSetModelNamePropertyToPropertyName()
        {
            OneToOne()
                .Mapping(m => {})
                .ModelShouldMatch(x => x.Name.ShouldEqual("Reference"));
        }

        [Test]
        public void OuterJoinShouldSetModelOuterJoinPropertyToValue()
        {
            OneToOne()
                .Mapping(m => m.OuterJoin.Auto())
                .ModelShouldMatch(x => x.OuterJoin.ShouldEqual("auto"));
        }

        [Test]
        public void PropertyRefShouldSetModelPropertyRefPropertyToValue()
        {
            OneToOne()
                .Mapping(m => m.PropertyRef(x => x.Name))
                .ModelShouldMatch(x => x.PropertyRef.ShouldEqual("Name"));
        }
    }
}