using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Note.Models;

namespace Note.Controllers;

public class NoteController : Controller
{
    private readonly ApplicationContext _dataBase;

    public NoteController(ApplicationContext dataBase)
    {
        _dataBase = dataBase;
    }

    public IActionResult Index()// это начальная страница, которую увидет пользователь
    {
        return View();
    }
    
    public IActionResult ShowNotes()
    {
        var notes = _dataBase.Notes.ToList();// получаем все значения notes из базы данных
        return View("ShowNotes", notes);
    }
    
    public IActionResult ShowScreenAddNote()// показать страницу добавления заметки
    {
        return View();
    }
    
    public IActionResult ShowNoteInfo(int id)
    {
        var note = _dataBase.Notes.First(note => note.Id == id);// ищем первое совпадение по id
        return View(note);
    }
    
    public IActionResult UpdateNote(int id, string title, string text)// метод обновления заметки
    {
        var note = _dataBase.Notes.First(note => note.Id == id);// ищем первое совпадение по id
        note.Title = title;// меняем заголовок заметки
        note.Text = text;// меняем текст заметки
        _dataBase.SaveChanges();// сохраняем изменения
        return ShowNotes();// вызываем метод для того, чтобы увидеть все наши заметки
    }
    
    public IActionResult AddNote(string title, string text)// метод добавления заметки
    {
        var note = new Note.Models.Note
        {
            Title = title, // меняем заголовок заметки
            Text = text // меняем текст заметки
        };

        _dataBase.Notes.Add(note);// добавили заметку
        _dataBase.SaveChanges();// сохраняем изменения
        return ShowNotes();// переходим на страницу, где показаны все наши  заметки
    }

    public IActionResult Privacy()
    {
        return View();
    }


    public IActionResult DeleteNote(int id)
    {
        var note = _dataBase.Notes.First(note => note.Id == id);// ищем первое совпадение по id
        _dataBase.Notes.Remove(note);
        _dataBase.SaveChanges();
        return ShowNotes();
    }
}