pipeline {
    agent any
    
    stages {
        stage('Restore Dependencies') {
            steps {
                // Restore dependencies for the tests
                sh 'dotnet restore'
            }
        }
        stage('Unit Tests') {
            steps {
                // Run the unit tests
                script {
                    def testResults = sh returnStdout: true, script: 'dotnet test --no-restore --no-build --logger "trx;LogFileName=test-results.trx" /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=./TestResults/Coverage/ /p:Filter=FullyQualifiedName~quickformapi.expresstaxexempt.com.Tests'
                    echo "Test Results:\n${testResults}"
                }
                post {
                    always {
                        // Archive the test results
                        archiveArtifacts 'test-results.trx'
                        // Archive the coverage results
                        archiveArtifacts 'TestResults/Coverage/**'
                    }
                }
            }
        }
    }
}
