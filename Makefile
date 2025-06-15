all: unload-agent build publish load-agent

build:
	dotnet build -c Release

publish:
	dotnet publish -c Release -r osx-arm64 --self-contained true -o ~/samurai-os-apps/hosam
	chmod +x ~/samurai-os-apps/hosam/HoSam.Host
	cp ./com.samurai-os.hosam.plist ~/Library/LaunchAgents/
	
load-agent:
	launchctl load ~/Library/LaunchAgents/com.samurai-os.hosam.plist

unload-agent:
	launchctl unload ~/Library/LaunchAgents/com.samurai-os.hosam.plist
