
using System.Collections.Generic;
using UniversitySystem.Core.Models;

namespace UniversitySystem.Core.Service
{
    public interface ISectionService
    {
        List<Section> GetAllSections();

        Section? GetSectionById(decimal sectionId);

        List<Section> GetSectionsByCourse(decimal courseId);

        decimal CreateSection(Section section);

        void UpdateSection(Section section);

        void DeleteSection(decimal sectionId);
    }
}
