pipeline {
    agent any
    
    stages {
        stage('Checkout') {
            steps {
                // Checkout the repository from GitHub
                git 'https://github.com/your/repo.git'
            }
        }
        
        stage('Restore Dependencies') {
            steps {
                // Restore dependencies for the tests
                sh 'dotnet restore'
            }
        }
        
        stage('Unit Tests') {
            steps {
                // Run the unit tests
                sh 'dotnet test --no-restore --no-build --logger "trx;LogFileName=test-results.trx"'
            }
            post {
                always {
                    // Archive the test results
                    archiveArtifacts 'test-results.trx'
                }
            }
        }
    }
}
