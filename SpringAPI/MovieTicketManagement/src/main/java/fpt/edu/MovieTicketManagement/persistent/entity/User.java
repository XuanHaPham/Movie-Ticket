package fpt.edu.MovieTicketManagement.persistent.entity;


import javax.persistence.*;
import java.util.Date;
import java.util.UUID;

@Entity
@Table(name = "User")
public class User {
    private UUID Id;
    private  String UserName;
    private  String Password;
    private  String RoleName;
    private Date TimeCreate;
    private Boolean Status;

    public User(UUID id, String userName, String password, String roleName, Date timeCreate, Boolean status) {
        Id = id;
        UserName = userName;
        Password = password;
        RoleName = roleName;
        TimeCreate = timeCreate;
        Status = status;
    }

    @javax.persistence.Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    public UUID getId() {
        return Id;
    }
    public void setId(UUID id) {
        Id = id;
    }

    @Column(name = "userName", nullable = false)
    public String getUserName() {
        return UserName;
    }
    public void setUserName(String userName) {
        UserName = userName;
    }

    @Column(name = "password", nullable = false)
    public String getPassword() {
        return Password;
    }
    public void setPassword(String password) {
        Password = password;
    }

    @Column(name = "roleName", nullable = false)
    public String getRoleName() {
        return RoleName;
    }
    public void setRoleName(String roleName) {
        RoleName = roleName;
    }

    @Column(name = "timeCreate", nullable = false)
    public Date getTimeCreate() {
        return TimeCreate;
    }
    public void setTimeCreate(Date timeCreate) {
        TimeCreate = timeCreate;
    }

    @Column(name = "status", nullable = false)
    public Boolean getStatus() {
        return Status;
    }
    public void setStatus(Boolean status) {
        Status = status;
    }

    @Override
    public String toString() {
        return "User{" +
                "Id=" + Id +
                ", UserName='" + UserName + '\'' +
                ", Password='" + Password + '\'' +
                ", RoleName='" + RoleName + '\'' +
                ", TimeCreate=" + TimeCreate +
                ", Status=" + Status +
                '}';
    }

    /*public string UserName { get; set; }

        public string Password { get; set; }

        public string RoleName { get; set; }

        public string TimeCreate { get; set; }

        public bool? Status { get; set; }*/
}
