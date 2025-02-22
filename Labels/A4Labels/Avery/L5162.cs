﻿namespace SharpPDFLabel.Labels.A4Labels.Avery
{
    public class L5162 : LabelDefinition
    {
        // all sizes are in mm
        public L5162()
        {
            _Width = 101.6;
            _Height = 33.867;
            _HorizontalGapWidth = 4.7752;
            _VerticalGapHeight = 0;

            _PageMarginTop = 21.1582;
            _PageMarginBottom = 21.1582;
            _PageMarginLeft = 3.9624;
            _PageMarginRight = 3.9624;

            PageSize = Enums.PageSize.A4;
            LabelsPerRow = 2;
            LabelRowsPerPage = 7;
        }
    }
}
