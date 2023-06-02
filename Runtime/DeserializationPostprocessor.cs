using System.Collections.Generic;

namespace Exam.Data
{
	public interface DeserializationPostprocessor
	{
		void RunDeserializationPostprocessing(ISet<DeserializationPostprocessor> alreadyHandled);
	}
}
