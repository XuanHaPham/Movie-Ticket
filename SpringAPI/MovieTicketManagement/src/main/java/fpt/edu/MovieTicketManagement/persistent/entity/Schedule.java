package fpt.edu.MovieTicketManagement.persistent.entity;

import javax.persistence.*;
import java.util.UUID;

@Entity
@Table(name = "Schedule")
public class Schedule {

    private UUID id ;
    private  UUID filmID;
    private String movieDate;
    private String movieTime;
    private int stock;
    private boolean status;
b
    public Schedule() {
    }

    public Schedule(UUID id, UUID filmID, String movieDate, String movieTime, int stock, boolean status) {
        this.id = id;
        this.filmID = filmID;
        this.movieDate = movieDate;
        this.movieTime = movieTime;
        this.stock = stock;
        this.status = status;
    }

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    public UUID getId() {
        return id;
    }
    public void setId(UUID id) {
        this.id = id;
    }

    @Column(name = "filmID", nullable = false)
    public UUID getFilmID() {
        return filmID;
    }
    public void setFilmID(UUID filmID) {
        this.filmID = filmID;
    }

    @Column(name = "movieDate", nullable = false)
    public String getMovieDate() {
        return movieDate;
    }
    public void setMovieDate(String movieDate) {
        this.movieDate = movieDate;
    }

    @Column(name = "movieTime", nullable = false)
    public String getMovieTime() {
        return movieTime;
    }
    public void setMovieTime(String movieTime) {
        this.movieTime = movieTime;
    }

    @Column(name = "stock", nullable = false)
    public int getStock() {
        return stock;
    }
    public void setStock(int stock) {
        this.stock = stock;
    }

    @Column(name = "status", nullable = false)
    public boolean isStatus() {
        return status;
    }
    public void setStatus(boolean status) {
        this.status = status;
    }

    @Override
    public String toString() {
        return "Schedule{" +
                "id=" + id +
                ", filmID=" + filmID +
                ", movieDate='" + movieDate + '\'' +
                ", movieTime='" + movieTime + '\'' +
                ", stock=" + stock +
                ", status=" + status +
                '}';
    }
}