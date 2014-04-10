<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="FilmQuizService" generation="1" functional="0" release="0" Id="4705ae99-c472-43ba-b075-601bac689a31" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="FilmQuizServiceGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="WCFService:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/FilmQuizService/FilmQuizServiceGroup/LB:WCFService:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="WCFService:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/FilmQuizService/FilmQuizServiceGroup/MapWCFService:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="WCFServiceInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/FilmQuizService/FilmQuizServiceGroup/MapWCFServiceInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:WCFService:Endpoint1">
          <toPorts>
            <inPortMoniker name="/FilmQuizService/FilmQuizServiceGroup/WCFService/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapWCFService:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/FilmQuizService/FilmQuizServiceGroup/WCFService/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapWCFServiceInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/FilmQuizService/FilmQuizServiceGroup/WCFServiceInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="WCFService" generation="1" functional="0" release="0" software="C:\Users\Rasmus Wismann\Documents\FilmQuiz-.NET-Project\FilmQuizService\FilmQuizService\csx\Release\roles\WCFService" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;WCFService&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;WCFService&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="WCFService.svclog" defaultAmount="[1000,1000,1000]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/FilmQuizService/FilmQuizServiceGroup/WCFServiceInstances" />
            <sCSPolicyUpdateDomainMoniker name="/FilmQuizService/FilmQuizServiceGroup/WCFServiceUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/FilmQuizService/FilmQuizServiceGroup/WCFServiceFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="WCFServiceUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="WCFServiceFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="WCFServiceInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="fe7581b4-c5fe-4a48-9618-352b9f276b76" ref="Microsoft.RedDog.Contract\ServiceContract\FilmQuizServiceContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="a996f694-17e6-490e-9f11-3d43fd0c39e1" ref="Microsoft.RedDog.Contract\Interface\WCFService:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/FilmQuizService/FilmQuizServiceGroup/WCFService:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>