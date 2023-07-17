pipeline {
    agent any
    
    stages {
        stage('Restore Dependencies') {
            steps {
                // Restore dependencies for the tests
                sh 'dotnet restore'
            }
        }
        stage('Unit Test') {
            steps {
                // Run unit tests before the build process
                // Assuming your test projects are set up and configured properly
                // Replace the following lines with your actual test commands

                // For tests in Services folder (assuming you use "dotnet test" for .NET Core projects)
                sh 'dotnet test Services/QForm990PFServiceTest.cs'
                
                // For tests in Controller folder (assuming you use "dotnet test" for .NET Core projects)
                sh 'dotnet test Controller/FullControllerTest.cs'
            }
        }
    }
}
