using DMStorage.Core.Models.Domains;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NPOI.SS.UserModel;
using NPOI.Util.Collections;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace DMStorage.Helpers
{
    public class FileHelper
    {
        public FileHelper()
        {
            
        }
        public static List<string> GetExcelColumns(Stream stream)
        {
            var columns = new List<string>();

            stream.Position = 0;
            IWorkbook workbook = new XSSFWorkbook(stream);
            ISheet sheet = workbook.GetSheetAt(0);
            IRow headerRow = sheet.GetRow(0);

            for (int i = 0; i < headerRow.LastCellNum; i++)
            {
                ICell cell = headerRow.GetCell(i);
                if (cell != null)
                {
                    columns.Add(cell.ToString());
                }
            }

            return columns;
        }
        public static List<string> GetExcelSheetNames(Stream stream)
        {
            var sheetNames = new List<string>();

            stream.Position = 0;
            IWorkbook workbook = new XSSFWorkbook(stream);

            for (int i = 0; i < workbook.NumberOfSheets; i++)
            {
                sheetNames.Add(workbook.GetSheetName(i));
            }

            return sheetNames;
        }
        public static List<string> GetExcelColumnsMachine(Stream stream, string sheetName)
        {
            var columns = new List<string>();

            stream.Position = 0;
            IWorkbook workbook = new XSSFWorkbook(stream);
            ISheet sheet = workbook.GetSheet(sheetName);
            IRow headerRow = sheet.GetRow(0);

            for (int i = 0; i < headerRow.LastCellNum; i++)
            {
                ICell cell = headerRow.GetCell(i);
                if (cell != null)
                {
                    columns.Add(cell.ToString());
                }
            }

            return columns;
        }
        public static List<MachineImport> GetPreviewDataMachine(Stream stream, string sheetName, Dictionary<string, string> columnMappings)
        {
            var data = new List<MachineImport>();

            stream.Position = 0;
            IWorkbook workbook = new XSSFWorkbook(stream);
            ISheet sheet = workbook.GetSheet(sheetName);
            int rowCount = sheet.LastRowNum;

            for (int i = 1; i <= rowCount; i++)
            {
                IRow row = sheet.GetRow(i);
                var model = new MachineImport();
                if (row != null)
                {
                    foreach (var mapping in columnMappings)
                    {
                        var columnIndex = GetColumnIndex(sheet, mapping.Key);
                        if (columnIndex.HasValue)
                        {
                            var cell = row.GetCell(columnIndex.Value);
                            SetModelProperty(model, mapping.Value, cell?.ToString());
                        }
                    }

                    data.Add(model);
                }
            }

            return data;
        }

        public static List<DeviceImport> GetPreviewDataDevice(Stream stream, string sheetName, Dictionary<string, string> columnMappings)
        {
            var data = new List<DeviceImport>();

            stream.Position = 0;
            IWorkbook workbook = new XSSFWorkbook(stream);
            ISheet sheet = workbook.GetSheet(sheetName);
            int rowCount = sheet.LastRowNum;

            for (int i = 1; i <= rowCount; i++)
            {
                IRow row = sheet.GetRow(i);
                var model = new DeviceImport();
                if (row != null)
                {
                    foreach (var mapping in columnMappings)
                    {
                        var columnIndex = GetColumnIndex(sheet, mapping.Key);
                        if (columnIndex.HasValue)
                        {
                            var cell = row.GetCell(columnIndex.Value);
                            SetModelProperty(model, mapping.Value, cell?.ToString());
                        }
                    }

                    data.Add(model);
                }
            }

            return data;
        }
        private static int? GetColumnIndex(ISheet sheet, string columnName)
        {
            IRow headerRow = sheet.GetRow(0);
            for (int i = 0; i < headerRow.LastCellNum; i++)
            {
                var cell = headerRow.GetCell(i);
                if (cell != null)
                {
                    if (cell.ToString() == columnName)
                    {
                        return i;
                    }
                }
            }
            return null;
        }

        private static void SetModelProperty(object model, string propertyName, string value)
        {
            if (propertyName != null)
            {
                var property = model.GetType().GetProperty(propertyName);
                if (property != null && !string.IsNullOrEmpty(value))
                {
                    property.SetValue(model, Convert.ChangeType(value, property.PropertyType));
                }
            }
        }
        public static List<string> GetProperties(string modelName)
        {
            var propertyNames = new List<string>();
            Type modelType = null;

            if (modelName == "Machine")
            {
                modelType = typeof(MachineImport);
            }
            else if (modelName == "Device")
            {
                modelType = typeof(DeviceImport);
            }

            if (modelType != null)
            {
                var propertyInfos = modelType.GetProperties();
                var simpleTypes = new System.Collections.Generic.HashSet<Type>
            {
                typeof(byte), typeof(sbyte), typeof(short), typeof(ushort),
                typeof(int), typeof(uint), typeof(long), typeof(ulong),
                typeof(float), typeof(double), typeof(decimal), typeof(bool),
                typeof(char), typeof(string), typeof(DateTime)
            };

                foreach (var prop in propertyInfos)
                {
                    if (simpleTypes.Contains(prop.PropertyType))
                    {
                        propertyNames.Add(prop.Name);
                    }
                }
            }

            return propertyNames;
        }
    }
}