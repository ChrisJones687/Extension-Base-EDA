//  Copyright 2005-2010 Portland State University, University of Wisconsin
//  Authors:  Robert M. Scheller,   James B. Domingo

using System.Collections.Generic;
using Edu.Wisc.Forest.Flel.Util;

namespace Landis.Extension.BaseEDA
{
    /// <summary>
    /// Parameters for the extension.
    /// </summary>
    public interface IInputParameters
    {
        /// <summary>
        /// Timestep (years)
        /// </summary>
        int Timestep {get;set;}
        //---------------------------------------------------------------------
        /// <summary>
        /// Template for the filenames for output maps. Provides the naming convention for the EDA intensity files (intensity of infection).
        /// </summary>
        string MapNamesTemplate {get;set;}
        //---------------------------------------------------------------------
        /// <summary>
        /// Template for the filenames for output SRD maps.
        /// </summary>
        //string SRDMapNames{get;set;}
        //---------------------------------------------------------------------
        /// <summary>
        /// Template for the filenames for output SRD maps.
        /// </summary>
        //string NRDMapNames{get;set;}
        //---------------------------------------------------------------------
        /// <summary>
        /// Template for the filenames for Epidemiological Disturbance Probability (EDP) output maps.
        /// </summary>
        //string EDPMapNames { get; set; }
        //---------------------------------------------------------------------
        /// <summary>
        /// Template for the filenames for epidemic (disease) mortality output maps (number of cohorts killed for each species of interest).
        /// </summary>
        string EPIMapNames { get; set; }
        //---------------------------------------------------------------------
        /// <summary>
        /// Name of log file.
        /// </summary>
        string LogFileName {get;set;}
        //---------------------------------------------------------------------
        /// <summary>
        /// List of Agent Files
        /// </summary>
        IEnumerable<IAgent> ManyAgentParameters{get;set;}
    }
}

namespace Landis.Extension.BaseEDA
{
    /// <summary>
    /// Parameters for the plug-in.
    /// </summary>
    public class InputParameters
        : IInputParameters
    {
        private int timestep;
        private string mapNamesTemplate;
        //private string srdMapNames;
        //private string nrdMapNames;
        //private string edpMapNames;
        private string epiMapNames;
        private string logFileName;
        private IEnumerable<IAgent> manyAgentParameters;

        //---------------------------------------------------------------------
        /// <summary>
        /// Timestep (years)
        /// </summary>
        public int Timestep
        {
            get {
                return timestep;
            }
            set {
                if (value < 0)
                        throw new InputValueException(value.ToString(),
                                                      "Value must be = or > 0.");
                timestep = value;
            }
        }

        //---------------------------------------------------------------------
        /// <summary>
        /// Template for the filenames for output maps. Provides the naming convention for the EDA intensity files (intensity of infection).
        /// </summary>
        public string MapNamesTemplate
        {
            get {
                return mapNamesTemplate;
            }
            set {
                MapNames.CheckTemplateVars(value);
                mapNamesTemplate = value;
            }
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Template for the filenames for epidemic (disease) mortality output maps (number of cohorts killed for each species of interest).
        /// </summary>
        public string EPIMapNames
        {
            get
            {
                return epiMapNames;
            }
            set
            {
                MapNames.CheckTemplateVars(value);
                epiMapNames = value;
            }
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Name of log file.
        /// </summary>
        public string LogFileName
        {
            get {
                return logFileName;
            }
            set {
                    // FIXME: check for null or empty path (value.Actual);
                logFileName = value;
            }
        }

        //---------------------------------------------------------------------
        /// <summary>
        /// List of Agent Files
        /// </summary>
        public IEnumerable<IAgent> ManyAgentParameters
        {
            get {
                return manyAgentParameters;
            }
            set {
                manyAgentParameters = value;
            }
        }

        //---------------------------------------------------------------------
        public InputParameters()
        {
        }
       
    }
}
