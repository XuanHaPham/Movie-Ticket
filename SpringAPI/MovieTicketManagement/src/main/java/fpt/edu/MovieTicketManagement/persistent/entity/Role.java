package fpt.edu.MovieTicketManagement.persistent.entity;


import javax.persistence.Entity;
import javax.persistence.Table;
import java.util.UUID;

@Entity
@Table(name = "Role")
public class Role {
    private UUID id;

}
