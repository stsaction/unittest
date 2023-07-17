pipeline {
    agent any
    
    stages {
        
        stage('Restore Dependencies') {
            steps {
                // Use the .NET Core CLI to restore the project dependencies.
                sh 'dotnet restore'
            }
        }
        
            stage('Run xUnit Tests') {
                steps {
                    // Use the .NET Core CLI to run the xUnit tests.
                    sh 'dotnet test --logger "trx;LogFileName=testresults.trx"'
                }
            }
        }
    
    post {
        always {
            // Archive test results for Jenkins to display in the build summary.
            junit 'testresults.trx'
        }
    }
}
        
