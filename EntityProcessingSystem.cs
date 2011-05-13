using System;
namespace Artemis
{
	public abstract class EntityProcessingSystem : EntitySystem {
		
		/**
		 * Create a new EntityProcessingSystem. It requires at least one component.
		 * @param requiredType the required component type.
		 * @param otherTypes other component types.
		 */
		public EntityProcessingSystem(Type requiredType,params Type[] otherTypes) {
			super(GetMergedTypes(requiredType, otherTypes));
		}
		
		/**
		 * Process a entity this system is interested in.
		 * @param e the entity to process.
		 */
		protected abstract void Process(Entity e);
	
		protected override void ProcessEntities(Bag<Entity> entities) {
			for (int i = 0, s = entities.Size(); s > i; i++) {
				Process(entities.Get(i));
			}
		}
		
		protected override boolean CheckProcessing() {
			return true;
		}
		
	}
}
