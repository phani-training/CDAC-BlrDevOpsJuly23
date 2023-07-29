# contains the instructions required for the docker to load the required dependencies for UR application.

FROM openjdk:11
WORKDIR /var/www/java
COPY . /var/www/java
RUN javac SimpleExample.java
CMD exec java SimpleExample