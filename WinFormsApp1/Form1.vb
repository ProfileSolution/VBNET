Imports System.DirectoryServices.ActiveDirectory
Imports System.Formats
Imports System.Numerics
Imports System.Reflection.Metadata
Imports System.Runtime.InteropServices

Public Class Form1

    Private PreApp, doc, app
    Private CheckInit = False, CheckDoc = False, CheckMat = False, CheckSTL = False,
            CheckBC = False, CheckMesh = False


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PreApp = CreateObject("STpre_Bx64net.Application.2023")
        CheckInit = True
        MessageBox.Show(text:="Initialisation of solver")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (CheckInit = False) Then
            MessageBox.Show(text:="Please Intialise the solver first")
            ' Application.Exit()
        End If
        If (CheckInit = True) Then
            doc = PreApp.GetDocument
            MessageBox.Show(text:="Initialisation of document")
            CheckDoc = True

        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (CheckDoc = False) Then
            MessageBox.Show(text:="Please Intialise the Doc first")
            'Application.Exit()
        End If
        If (CheckDoc = True) Then
            Dim v = doc.CreateFluidMaterial("air20", 1.205, 0.0000182, 1006.0, 0.0256, 0.0035)
            Dim c = doc.CreateSolidMaterial("fe", 7870.0, 442.0, 80.3,,, 0.9)
            MessageBox.Show(text:="Created fluid material and solid material")
            CheckMat = True
        End If

    End Sub

    Public Function abs(number As Integer) As Integer
        If number < 0 Then
            Return -number
        Else
            Return number
        End If
    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If (CheckMat = False) Then
            MessageBox.Show(text:="Please select the material first")
            'Application.Exit()
        End If
        If (CheckMat = True) Then
            If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                OpenFileDialog1.InitialDirectory = "D:\" 'Set the directory name  
                OpenFileDialog1.Title = "Open STL File" 'Set the title name of the OpenDialog Bo
                Dim file_path
                file_path = OpenFileDialog1.FileName

                Dim file_pointer
                file_pointer = doc.OpenCadFile(file_path, 1, Nothing, Nothing)

                'Domain selection
                Dim all_model = doc.GetAllModelArray("parts")

                Dim min0, min1, min2
                min0 = 1000000.0
                min1 = 1000000.0
                min2 = 1000000.0

                Dim max0, max1, max2
                max0 = -1 * 1000000.0
                max1 = -1 * 1000000.0
                max2 = -1 * 1000000.0

                For Each element In all_model
                    Dim searchString = element.GetBoundingBox

                    If min0 > searchString(0) Then
                        min0 = searchString(0)
                    End If

                    If min1 > searchString(1) Then
                        min1 = searchString(1)
                    End If

                    If min2 > searchString(2) Then
                        min2 = searchString(2)
                    End If

                    If max0 < searchString(3) Then
                        max0 = searchString(3)
                    End If

                    If max1 < searchString(4) Then
                        max1 = searchString(4)
                    End If

                    If max2 < searchString(5) Then
                        max2 = searchString(5)
                    End If

                Next
                Dim factor = 5.0




                Dim minN0, maxN0, absmin0, absmax0, width0
                Dim minN1, maxN1, absmin1, absmax1, width1
                Dim minN2, maxN2, absmin2, absmax2, width2





                If min0 > 0 Then
                    minN0 = min0 - (factor - 1) * min0
                Else
                    minN0 = min0 + (factor - 1) * min0
                End If

                If min1 > 0 Then
                    minN1 = min1 - (factor - 1) * min1
                Else
                    minN1 = min1 + (factor - 1) * min1
                End If

                If min2 > 0 Then
                    minN2 = min2 - (factor - 1) * min2
                Else
                    minN2 = min2 + (factor - 1) * min2
                End If

                If min0 = 0 Then
                    minN0 = -factor * max0
                End If

                If min1 = 0 Then
                    minN1 = -factor * max1
                End If

                If min2 = 0 Then
                    minN2 = -factor * max2
                End If

                If max0 = 0 Then
                    maxN0 = factor * min0
                End If

                If max1 = 0 Then
                    maxN1 = factor * min1
                End If

                If max2 = 0 Then
                    maxN2 = factor * min2
                End If


                absmin0 = abs(min0)
                absmax0 = abs(max0)

                absmin1 = abs(min1)
                absmax1 = abs(max1)

                absmin2 = abs(min2)
                absmax2 = abs(max2)


                width0 = absmin0 + absmax0 + 2 * factor * abs(absmax0 - absmin0)
                width1 = absmin1 + absmax1 + 2 * factor * abs(absmax1 - absmin1)
                width2 = absmin2 + absmax2 + 2 * factor * abs(absmax2 - absmin2)

                Dim Domain = doc.SetCartesianDomain("domain", minN0, minN1, minN2, width0, width1, width2)

                Domain.SetMaterial("air20")
                Domain.SetInitTemperature(20.0)
            End If
            CheckSTL = True

        End If

    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        If (CheckSTL = False) Then
            MessageBox.Show(text:="Please create Domain")
            'Application.Exit()
        End If

        If (CheckSTL = True) Then
            'Dim model 
            Dim model_array, part_array, retval, aircon, flux, flux1
            Dim result
            result = ""

            part_array = doc.GetAllModelArray("parts")

            Dim i

            'Setting attribute to the function
            For Each element In part_array
                element.SetAttribute("cface")
                element.SetInitTemperature(300)
            Next

            'Modelling Air condition
            'Dim aircon
            retval = doc.SetAnalysisType("aircon", "T")
            aircon = doc.SetAirconModel("ACModel")

            'doc.SetAirconCondition "IDKAC","aircon"

            'Ability is expressed in (W) not in (kW)
            'Power wattage
            retval = aircon.SetParam("ability", 2500000)

            'Setting fixed flow rate BC
            'CFM,speed,
            flux = doc.SetFluxFlow("FluxBC", 11772.0, "CFM", 0.0, 42.7, 0.0, 0.0, 0.0, "supply")

            'Setting fixed flow rate BC
            flux1 = doc.SetFluxFlow("ReverseFluxBC", -11772.0, "CFM", 0.0, 42.7, 0.0, 0.0, 0.0, "return")

            'Searching for Inlet key word and applying inlet BC
            'Function search parts by name

            For Each element In part_array
                Dim searchWord
                searchWord = "Inlet"
                Dim searchString
                searchString = element.GetName
                Dim position
                position = InStr(1, searchString, searchWord, vbTextCompare)
                If position > 0 Then
                    element.AppendValue("FluxBC")
                End If

                'Searching for outlet key word and applying inlet BC
                Dim searchExhaustWord = "exhaust"
                Dim position_Exhaust
                position_Exhaust = InStr(1, searchString, searchExhaustWord, vbTextCompare)
                If position_Exhaust > 0 Then
                    element.AppendValue("ReverseFluxBC")
                End If

                'Condition of model
                If searchString = "Building" Then
                    element.SetAttribute("obstacle")
                End If

                If searchString = "Solid1" Then
                    element.SetAttribute("obstacle")
                End If

            Next

            PreApp.Visible = True
            PreApp.UserControl = True

            CheckBC = True

        End If

    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'Get the folder location 
        If (CheckBC = False) Then
            MessageBox.Show(text:="Please apply the boundary condition first")
            'Application.Exit()
        End If

        If (CheckBC = True) Then

            Dim spath = My.Computer.FileSystem.CurrentDirectory

            MsgBox("CAB files are written in this folder" & spath)

            Dim mesh = doc.GetMesher()

            'Get the object of the root block.
            Dim blk1 = mesh.GetBlock("root")

            'Set the type of Vertex detection for Auto-division.
            '"main" indicates the selection of "Representative vertex".
            mesh.SetGridParam("division_type", "main")

            'Set the total number of elements for Auto-division.
            '(Note) This function sets the number of elements in each axis direction.
            'When the numbers of elements in Y and Z axis directions are set to 0,
            ' the total number of elements in entire domain is equal to the value specified for
            ' the X axis direction.
            mesh.SetGridParam("division_num", 30000, 30000, 30000)

            'Set the threshold element size of the root block to (0.1, 0.1, 0.1).
            blk1.SetParam("limit", 0.1, 0.1, 0.1)

            'Set the internal and external geometric ratios of the root block to 1.0.
            blk1.SetParam("ratio", 1.0, 1.0, 1.0)
            mesh.SetGridParam("outer_ratio", 1.0, 1.0, 1.0)

            'Execute gridding.
            mesh.ExecuteGrid("auto1")

            'Execute element auto-division.
            mesh.ExecuteElement

            'Set the project name to "ex1".
            '(Note) All files used in Solver are named as "ex1".
            doc.SetFileName("project", "ex1")

            'Set the last cycle number to 200.
            doc.SetCycle("end", 200)

            'Output a CAB file to the folder where this script is located.
            doc.SaveCabFile(spath & "ST-ex1_eng.cab")

            'Output an S file to the folder where this script is located.
            doc.SaveSFile(spath & "ST-ex1_eng.s")

            CheckMesh = True

        End If

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If (CheckMesh = False) Then
            MessageBox.Show(text:="Please select the mesh first")
            ' Application.Exit()
        End If

        If (CheckMesh = True) Then
            Dim scMonitor = CreateObject("ST.scMonitor_Bx64net.Application.2023")
            app = scMonitor.GetInterface("1.0")
            app.Visible = True
            app.UserControl = True

            Dim Sfile_path = My.Computer.FileSystem.CurrentDirectory + "/ST-ex1_eng.s"

            MsgBox("Path is written here" & Sfile_path)
            Dim job = app.CreateSolverJob(Sfile_path)
            app.Execute(job)
            app.Quit()

        End If

    End Sub

End Class
