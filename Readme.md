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
docker build -t java-app
docker run --name myapp java-app
```
- t is the flat that tells the docker to allocate virtual terminal within the container to start the application and view the results. 