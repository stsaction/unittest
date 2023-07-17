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
                sh 'dotnet test quickformapi.expresstaxexempt.com.Tests.csproj'
            }
        }
    }
}
