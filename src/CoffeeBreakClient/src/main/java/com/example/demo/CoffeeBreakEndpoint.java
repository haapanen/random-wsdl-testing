package com.example.demo;
import java.time.Instant;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.ZoneId;
import java.util.Date;
import java.util.GregorianCalendar;

import org.datacontract.schemas._2004._07.coffeebreakservice.CoffeeBreakRequest;
import org.datacontract.schemas._2004._07.coffeebreakservice.CoffeeBreakResponse;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

import javax.xml.datatype.DatatypeConfigurationException;
import javax.xml.datatype.DatatypeFactory;

@Endpoint
public class CoffeeBreakEndpoint {
    private static final String NAMESPACE_URI = "http://schemas.datacontract.org/2004/07/CoffeeBreakService";

    @PayloadRoot(namespace = NAMESPACE_URI, localPart = "requestCoffeeBreak")
    @ResponsePayload
    public CoffeeBreakResponse requestCoffeeBreak(@RequestPayload CoffeeBreakRequest request) throws DatatypeConfigurationException {
        CoffeeBreakResponse res = new CoffeeBreakResponse();

        LocalDateTime ldt = LocalDateTime.now();
        Instant instant = ldt.atZone(ZoneId.systemDefault()).toInstant();
        GregorianCalendar c = new GregorianCalendar();
        c.setTime(Date.from(instant));
        res.setCoffeeBreakTime(DatatypeFactory.newInstance().newXMLGregorianCalendar(c));

        return res;
    }
}
