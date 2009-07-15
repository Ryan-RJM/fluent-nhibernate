using System;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;
using FluentNHibernate.MappingModel.Collections;

namespace FluentNHibernate.Conventions.Instances
{
    public class OneToManyCollectionInstance : CollectionInstance, IOneToManyCollectionInstance
    {
        private new bool nextBool;

        public OneToManyCollectionInstance(ICollectionMapping mapping)
            : base(mapping)
        {
            nextBool = true;
        }

        IOneToManyInspector IOneToManyCollectionInspector.Relationship
        {
            get { return Relationship; }
        }

        public new IOneToManyCollectionInstance Not
        {
            get
            {
                nextBool = !nextBool;
                return this;
            }
        }

        public new IOneToManyInstance Relationship
        {
            get { return new OneToManyInstance((OneToManyMapping)mapping.Relationship); }
        }
    }
}