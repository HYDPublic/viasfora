﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Winterdom.Viasfora.Contracts;

namespace Winterdom.Viasfora.Options {
  [Guid(Guids.SqlOptions)]
  public class SqlOptionsPage : DialogPage {
    private ILanguage language = SettingsContext.GetLanguage(Constants.Sql);

    public override void SaveSettingsToStorage() {
      base.SaveSettingsToStorage();
      language.Settings.ControlFlow = ControlFlowKeywords.ToArray();
      language.Settings.Visibility = VisibilityKeywords.ToArray();
      language.Settings.Linq = LinqKeywords.ToArray();
      language.Settings.Enabled = Enabled;
      language.Settings.Save();
    }
    public override void LoadSettingsFromStorage() {
      base.LoadSettingsFromStorage();
      ControlFlowKeywords = language.Settings.ControlFlow.ToList();
      VisibilityKeywords = language.Settings.Visibility.ToList();
      LinqKeywords = language.Settings.Linq.ToList();
      Enabled = language.Settings.Enabled;
    }

    [LocDisplayName("Enabled")]
    [Description("Enabled or disables all Viasfora features for this language")]
    public bool Enabled { get; set; }

    [LocDisplayName("Control Flow")]
    [Description("Control Flow keywords to highlight")]
    [Category("SQL")]
    [Editor(Constants.STRING_COLLECTION_EDITOR, typeof(UITypeEditor))]
    [TypeConverter(typeof(Design.StringListConverter))]
    public List<String> ControlFlowKeywords { get; set; }

    [LocDisplayName("Visibility")]
    [Description("Visibility keywords to highlight")]
    [Category("SQL")]
    [Editor(Constants.STRING_COLLECTION_EDITOR, typeof(UITypeEditor))]
    [TypeConverter(typeof(Design.StringListConverter))]
    public List<String> VisibilityKeywords { get; set; }

    [LocDisplayName("Statement")]
    [Description("Statement keywords to highlight")]
    [Category("SQL")]
    [Editor(Constants.STRING_COLLECTION_EDITOR, typeof(UITypeEditor))]
    [TypeConverter(typeof(Design.StringListConverter))]
    public List<String> LinqKeywords { get; set; }
  }
}
