all: unload-agent build publish load-agent

build:
	dotnet build -c Release

run:
	dotnet run --project ./hosam/hosam.csproj -c Release

appPath = ${HOME}/.samurai-os-apps
agentDir = ${HOME}/Library/LaunchAgents
agentFile = ${agentDir}/com.samurai-os.hosam.plist

publish:
	dotnet publish -c Release --self-contained true -p:PublishDir=${appPath} -p:PublishSingleFile=true -p:PublishTrimmed=true -p:EnableCompressionInSingleFile=true
	chmod +x ${appPath}/hosam
	cp ./com.samurai-os.hosam.plist ${agentDir}/

load-agent:
	launchctl load ${agentFile}

unload-agent:
	launchctl unload ${agentFile}
