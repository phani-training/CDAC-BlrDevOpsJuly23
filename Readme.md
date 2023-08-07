# DevOps training by Phaniraj @9945205684
## Sub Topics:
1. DevOps
2. Docker
3. Jenkins
4. Microservices and Yml
5. Kubernetes

#### What is DevOps?
- DevOps stands for Development and Operations. These are the 2 set of teams that collaborate in any project deployement cycle. The Developer Team and the Operations team. 
- The Developer team will be responsile for Requirement Gathering, Designing, Developing Unit Tests, Implementation, Integration and Finally the Deployment. The StakeHolders will be Product Owner, Project Manager, Team Leads, Senior Programmers, Programmers and QA Teams. 
- The Operations team will be responsible for Autmation Testing, App Evaluation, Integrations and Final Deployment to the End Customer. 
- In most of the old scenarios, the operations team would come at last only to provide the deployement support and execution support of the Product. In this case, the Ops team are unaware of the technical aspects required for the Application. Even small updates that are required due to any version incompatability of the software, were not solvable by the Ops Team.
- UAT (User Acceptance Tests) was conducted by one user of the Application (Customer) who understands the process very well and the Application usage. He/She ensure that the Application meets the expectations of the Customer. Finally on their Approval, a PCR(Project Closure Report) would be created, there by giving a final Handshake b.w the Customer and the Organization. 
- The Ops Team will comprise of Automation Testers, Product Evaluators, UAT Engineers and Customer Users who use the Product. 

#### Challenges in this setup?
- Many a time, the Ops team is unaware of the technical parts required for the Application. 
- Integration of multiple Config files across the Application will be huge. Sometimes taking days to resolve. 
- In the current scenarios, Apps are expected to be created partially, deployed and continue the development of the application. This is called as CI/CD(Continuous Integration/Continuous Development)
- In this scenario, the Ops team and the Dev Team should work together from the begining during the Sprint cycles and do collaborative work on resolving deployment issues like versioning of packages that U use in the Application, auditing of the compatibilities(Vernabilities) and helping each other in understanding both the sides of the Projec execution. 

#### Why DevOps?
1. Before DevOps, the Dev Team and the ops team were seperate entities and worked in complete Isolation. 
    -   With this mindset, the Ops team and the Dev Team were isolated and operations procedure was done always at the end of the development. 
    - It consumed more time that the regular short build cycles.
    - Unexpected challenges used to popup with no clue from the developer Team. 
    - Most of the time, the Deployment process was done manually and could have some human errors in the Production Environment that would take days to resolve. 
2. With DevOps, S/W delivery will be fast and easy. It increases the deployment easiness. 
    - Deployment is made in small parts and with first deployment(Within the 1 or 2 sprints), U will come across the challenges and will be aware of the fixes that needs to be made.  
    - DevOps maintains history which helps in fastening the future deployment processes as you would be having certain experience with your previous deployment.
    - According to the Industry analysis, the speed of deployment done thru DevOps have increased the speed of the TAD(Total Application Delivery) by over 20%.
    - Always these operations which involve CI/CD would happen with tools and services like GIT(REPOs), JENKINS(CI-CD Tool), Docker(Containers) and Kubernetes(Container Orchastrization tool). There are many other tools that help in performance monitoring and Application management(JIRA). 

#### How Apps are deployed in Devops?
1. With ADM(Agile Development Methodology), UR Scrum master will plan the sprints. 
    - Sprints are short span targets that are realistic & supposed to be met with the scope of development to be a minor one. Ideally the Sprint duration will be for 2-3 weeks.
    - The Sprint planning includes the division of the tasks and given priorities based on the milestones agreed upon. This includes identifying the resources who develop it for each task.
    - The participants for the sprint would be Scrum Master, Leads, Sr. Engineers, Jr. Engineers and a Tester. Sometimes, the DevOps Engineer will also join the initial Sprint cycles to help in ensuring the CI-CD process is in place. This will make the process smother over the time.
2.  During the Design time, the Developers would create the required Unit Tests for the Product. The QA Engineers will provide the Testing Environments for the e2e Testing. The DevOps person will create a pipeline in CI tool and will automate the process when any Dev Code is pushed into the REPO.
         
### Docker
- Docker is a centralized platform for packaging and deploying apps(REST APIs, Microservices, Small Internet Apps) in a closed environment that is created to replicate the actual Production environment. It is very similar to VMs but architecturally they are different. 
- Docker makes UR App building process smoother which includes the building, running, testing and maintainence of the Application with out additional OS. 
- Docker uses a concept called CONTAINERS. Each container is a closed Environment that places the Application along with the dependencies required for the application to run. Here each App is stored in a container which has all the runtime dependencies(Runtime Environments, packages, configs) required for your application excluding the OS. 

#### How Dockers are different from VMs
- Both of them are used for virtualization. 
- Docker and VMs are very similar in providing an isolated Environment for Apps to run in, but VMs use the internal hardware of the hosting environment and share the resources. Docker uses a kernel to run the application without using much of the resources of the Hosting Machine. VMs share the resources with isolation done for each processes. Docker resources are shared among all of them. In VMs, U cannot access the resources from outside the system as thye have Hypervisor that restricts external access to it. But in Dockers U can. 
- VMs(App + Guest OS) -> Hypervisor -> Host OS -> Hardware. 
- Containers(App + Config + dependencies) -> Container Engine -> Host OS -> Hardware. 
- Unlike VNs, dockers do not boot up their internal OS. Rather they run on the top of the hosting OS. It is faciliated by a container Engine(Linux). 

#### Installing Dockers in UR Machine. 
1. Install the WSL(Windows SubSystem for Linux) which is a prerequiste for installing Dockers on Windows Machine. To install the WSL, U can run the following command in Command prompt with elevated Previlages:
```
wsl -- install
```
2. After the installation of WSL, U should restart the machine and download the docker desktop app from the docker website. Install the software and run the Docker Desktop. If possible, allow the Docker to run at bootup. 
3. With this, U can download the images of popular softwares that can be used in ur machine without a need to explicitly install it in UR machine, so that hardware resources can be managed. 

#### Install Mongodb in Docker
1. Run the following commands in the order to install Mongodb inside ur docker desktop
```
docker pull mongodb/mongodb-community-server
docker run --name mongo -d mongodb/mongodb-community-server:latest
docker container ls
docker exec -it mongo mongosh
show dbs
use testDb
db.testDb.insertOne({}) 
```

#### Install MySql in Docker
```
docker pull mysql
docker run -d --name mysql-container -e MYSQL_ROOT_PASSWORD=apple123 -p 3306:3306 mysql
docker ps
docker exec -it mysql-container mysql --password
For connecting MySql from Java App:
hostname : localhost
port:3306
username : root
password: apple123
```

#### Exercise:
Create a Java App that connects to the MySQL database available in the container and display the records in the Console. 

#### How to create a Java App and deploy it in a Docker?
1. Create the java app that U want to build and test in ur local machine.
2. Creare the Dockerfile with the inputs shared in the dockerfile.
3. Run the following commands in the order from the terminal to push the image in the docker 
```
docker build -t java-app .
docker run --name myapp java-app
```
- t is the flat that tells the docker to allocate virtual terminal within the container to start the application and view the results. 

## Jenkins

### Continuous Integration. 
- An orchestration of a chain of activities to be performed whena code is pused to the REPO and the rest of the Operations after the push like building the App, Running the Unit Tests, Running the Linting feature, performing Automation Testing, Logging, Post build operations like running the Docker file to place the application in a container and auditing feature.
- To do all these things, we might not need a exclusive resource to monitor these activities. This is where a CI tool will be essential.
- CI tool will e responsible to keep track on any code change that happens in the Repo, which trigger a series of tasks along with a final post build operation which could complete the process. 
- JENKINS is one of the most popular CI/CD Tool. 

### How JENKINS Work?
- It is a Service side Web App that runs on Apache Tomcat. It can run on multiple platforms. TO use Jenkins, we need to create pipelines or a group of tasks(JOB) which is automated and work behind the scene. It also provides an option to monitor the environment all the time. 
- Jenkins internally uses 3rd party tools to build, test and do other jobs, raising reports about the performance of the Application, triggering emails to all the stake holders if any process status has changed(Process, Completed, Failed). 

#### How to install and run the JENKINS to build a simple Java Application.
1. Download the JDK 8.0 or later, Set the Environment variable like JAVA_HOME, JRE_HOME and Path. 
2. Download the Jenkins from the Home Website.
3. During the Installation, the wizard asks for the JRE Location which u could provide
4. U could optionally set the port no from which the JENKINS service be availed. 
5. U can login to the Jenkins Application using secret password provided by the instalation setup. Open the Jenkins app from the browser and use the following URL:
http://localhost:9000/
6. U can provide UR own user name and get the Preset password available in UR local machine at C:\ProgramData\Jenkins\.jenkins\secrets\initialAdminPassword. After logging it, U could reset the password as per UR requirements.

### Creating a CI feature in Jenkins
1. Open the Jenkins Dashboard by browing to http://localhost:9000
2. Click the + Icon to create a Project and allocate a job for the project. Provide the required description. 
3. Select the location of the source code by either setting the GIT REPO or to any local folder. In our example, we are selecting a local folder. Select Custom Workspace by clicking Advanced Button in the General Section. The location of the folder that has UR code to build should be entered in the location Edit box. It should be the absolute path of the Directory. 
4. In the Build steps, select the Windows Command Bat file and provide the required instructions
```
javac ./SimpleExample.java
java SimpleExample
```
5. In real time, POST BUILD settings could be set to run certain test casses or create the App in the docker Environment. 
6. Once U save the inputs, U could come to the Dashboard of the Jenkins to explicitly run the Build. 
7. U can also automate the build process by choosing build Periodically option
```
H/5 * * * *
@midnight
```

### Microservices
1. They are small scale apps that are created while breaking down a large App into small modular units which are designed to work independently of one- another. In current scenario, we might develop very large complex apps that usually takes longer time to build and deploy. Deployment complexity will increase.
2. With new Development methodologies where the final product is never understood and only small updations of the Application happens and is pushed frequently, then U might divide UR App into smaller target reachable units. 
3. With this, UR code building will be small, deployment will be easy as U can place this small app into a container like Docker container and maintain it.
4. Microservices can be created using various technologies like java, .NET and Open sources like Nodejs Express, Nestjs and many more. 
5. In our example, we will create a service using .NET CORE and Docker to publish the Application.  
6. U will select the ASP.NET CORE WEb API project and develop the REST API Required. 
7. Database will be from the another docker container for which we orchestrate it using Docker Compose. The file is shared. U should right click on the Project, Add and select Orchestration tool which creates a new project with yml file created. Modify the file to suit UR requirement.
8. Build the Application and test it using swagger. 
9. Further U can create a React App that consumes the REST API in UR React App. U must have additional Middleware like CORS to enable cross origin requests.   


# Kubernetes(K8s)
- It is a container management system developed on Google platform. It's main purpose is helping in managing the Containerized Apps on various platforms like cloud, Virtual Servers and local servers. It is said to be one of the most popular Container management Tools. 
- It is purely a cloud based environment. It comes with many automation tools that will be used to maintain the large scale containers as one Unit. 
- As DevOps Engineer, one will get skills on using these automation tools to manage the Applications and ensure that no break down of the software happen. 
- It uses a concept called CLUSTERS where each cluster is a repository of 100s of containers grouped into Worker nodes or PODs. Each POD might be an Application that has multiple containers in it. Each container can have one or more Microservices in it. 
- K8s maintain multiple clusters for the management of the nodes. The Application will be available to user thru Primary Cluster. If the primary cluster fails for maintainence or any other reason, a secondary cluster will be made available for the Application to continue its services to the Customer. Once the Primary Cluster is back to work, a cached state of the secondary cluster is pushed into the Primary one and the Application continues to provide the services. 

### How K8s work?
- It is linux based Environment that shares lots of resources required to manage UR Complex Apps. It is primarily used for Distributed Computing Applications where the K8s abstract the underlying hardware resources and offers std and consistant UI that one can monitor from a common place. 
- This UI will be used by the Dev Ops Engineer who will be responsible for the maintainence of the Application. 
- The UI looks similar to a Dashboard of JENKINS, where he/she can monitor multiple applications, clusters and allocate the resources required for each of the Applications. 
- The DevOps Engineer also determines the amount of resources that each App may require and allocate the resources accordingly. 

### Issues:
1. It needs a heavy infrastructure to showcase the Application. 
2. The Complete pipeline is done by a team of testers, DevOps Engineers and QAT teams. 
3. Its a collaborative work to make UR services hosted in a K8s server. Its not so user friendly. Ofcourse, there are many UI tools to manage these infrastructure. 

https://youtube.com/watch?v=X48VuDVv0do&feature=shares
U can view this tutorial for further reference. 

### Cloud Computing
- Cloud Computing refers to an ability of a system to store the data or applications on a remote servers, process data or applications from the servers and access data via internetl. 
- Cloud Computing provides scalability, cost-effectiveness and security to organizations to manage their IT Operations. 
- It works on Pay-On-Use basis for individuals and organizations. It is an on-demand availability of the System resources and computing power without active management by the User. 

#### Examples
1. Cloud based Virtual Desktops: These help the users access their systems and applications by using any device from anywhere. Examples are AWS, VM ware, Horizon Cloud and Virtual Windows of MS.
2. Cloud Backup and Cloud Storage: Cloud storage provides safe and scalable storage options for organizations to store and provides a backup of the data for a stable environment without worry of loss or data corruption and is well managed by professional Engineers
3. Infrastructure-as-a-Service(IaaS): It helps businesses to scale their computer resources up and down whenever needed without any requirement of capital expenditure on physical infrastructure. Examples of IaaS providers are AWS, Google Cloud and Microsoft Azure. 
4. Software-as-a-Service(SaaS): Users get a centralized data and applications hosted in cloud, rather than installing and running them on local devices. Examples of SaaS are SalesForce, DropBox, MS Office 365 and many more. 
5. Platform-as-a-Service(PaaS): They are used to build apps, deploy and manage the real time apps that they develop and host it in cloud. Examples of PaaS service providers are Google App Engine, Microsoft Azure etc.   

#### Types of cloud computing:
- public cloud computing:
    - Easily allowing accessibility to systems and services to its clients and users. IBM, Google, Amazon, MS are some of the popular public cloud service provides. They are well suited for Small enterprises which can start their businesses without large upfront investments by completely relying on the Public infrastructure for their IT needs. 
    - High Scalability, Cost reduction, reliability and a quick Disaster recovery. 
    - Disadvantages include Loss of control over the data, data security and privacy, limited visibility and unpredictable Cost.

- Private cloud Computing. 
    - Private clouds work on private infrastructure where some part of the setup is owned by the end users. This will help the users to have dynamic provisions of computer resources. 
    - There could be schemes like managing the cloud and proportionally billing of the different departments or sections of an Large Enterprise. Examples are HP Data Centers, Elastic-Cloud of AWS and Microsoft. 
    - Customer info protection, safe disaster management systems like system monitoring and maintenance, uptime services and data replications and with large support of standard operating procedures and operations. 
    - Disadvantages will be restricted area of access, experts to handle private clouds in your environment will be costly. 
- Hybrid Cloud Computing:
    - A hybrid cloud is a heterogenous Distributed system formed by combining facilities of the public cloud as well as the private cloud. 
    - As private clouds are within the environment, an immediate scale on demand and handling peak loads is difficult. Here Public clouds can help us. So a mix of both private and public is called as Hybrid Model. 
    - Cost, Speed and security. 
    - Businesses lack the internal knowledge required to create such hybrid environments, managing the security is more challenging as different levels of access and security considerations may apply for different environments. Managing the hybrid cloud may be difficult as new PaaS or any other infrastructure needs to be integrated and managed. 
- Community Cloud Computing.
    - Distributed Systems that are created by integrating the services of different clouds to address the specific needs of an industry or a business sector. 
    - Infrastructure is shared b/w the organizations that have shared concerns or tasks. A 3rd party will manage the cloud.
    - Cost effectiveness as the cloud is shared by numerous organizations and community. 
    - It is adapter and scalable as it works with every user and users can alter their data and usability according to their needs and requirements.
    - Not all businesses are willing to share the resources. It is difficult for the organizations to share the duties. 
    - Media industry can come up with content generations with extended ecosystems with its partners. 
    - Health industry : community clouds can share the information and knowledge on the the global level with sensitive data in the private infrastructure. 
    - Scientific research: Organizations with common interests in science do share a large distributed infrastrucure for scientific computing.
    ### Cloud Computing Apps:
    - Cloud computing uses servers, storages and network hypervisors to manage all the infrastructure required for managing the software. 
    - Various tools are available to manage the services of the cloud. 
    - Popular Deployment software are available to deploy and combine the Apps over cloud.  
    - Virtualization of cloud, Software and hardware are provided by prominent cloud service vendors: 
        - AWS: EC2(Elastic Cloud Compute) and S3: for Databases
        - Azure: MS cloud environment that provides Computing services, Data Servics using Azure SQL, Active Directory Services and network services. It also provides CI/CD feature and tools to maintain Agile Development tasks. 

### Virtualization of cloud computing and types
- It is a technique on how to seperate a service from the underlying physical delivery of that service, It creates a virtual version of the computer hardware using a specialized software.
- One of the most cost-effective, hardware reducing and energy saving techniques used by cloud providers. It allows sharing of single physical instance of a resource or an application among multiple consumers at a time. 
- Virtualization is practically implemented in IaaS as it plays a fundamental role in efficiently create such infra models. 
Apps->Binary libs->Guest OS->Hypervisor->Host OS->Host hardware

- application virtualization, Network Virtualization, Desktop, storage, server and data virtualization. 


Examples of Cloud
AWS:
EC2: Elastic Compute Cloud is a computing service which is a virtual computer that runs on cloud. EC2 is infrastructure as a Service. 
EBS: Elastic Bean Stalk: used for hosting web apps. It is a managed service for web apps, its a preconfigured EC2 instance that directly takes up UR application code and Env. configs and use it automatically. It a Platform as a Service.  
S3: Amazon S3(Simple Storage Service) its a high speed, low cost scalable storage service provided by AWS. U can store objects upto 5 TB. Stores the data in the form of BUCKETS. Each Bucket name is unique across S3. 
Amazon Cloud Watch: Services for monitoring and observing resoruces at real time built in for DevOps engineers, IT managers, Developers. It provides users with data and actionaable insights to monitor respective apps, simulate data changes, in the form of logs, metrics, events and also provide view of AwS resouces, apps and services that run within AWS. 
EKS: Elastic Kubernetes Services that is fully managed service that can allow to run Kubernetes on AWS. 

