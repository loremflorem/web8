using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Threading;
using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.InlineQueryResults;

namespace WebApplication7
{
    public class Program
    {
        static ITelegramBotClient botClient;
        static Message message;

        static private short available = 10;
        static private Queue buyer = new Queue();
        static private Queue product = new Queue();
        static private Regex regex = new Regex(@"0-10");





        static private int my = 880957692;

        static private string primary_channel = "@flashersheaven";
        static private string holder = primary_channel;
        static private string hiphop = "@hiphopflash",
            rick_and_morty = "@rickandmortyflash",
            inde = "@indeflash",
            sports = "@sportflash",
            marvel = "@Marvelsflash",
            anime = primary_channel,
            art = "@artisticflash",
            starwars = primary_channel,
            space = "@artisticflash",
            got = primary_channel,
            rock = "@rocksflash",
            action = primary_channel,
            commical = primary_channel,
            others = primary_channel;
        public static void Main(string[] args)
        {

            botClient = new TelegramBotClient("943290333:AAH_ttTEnIkTkQbCz-3unnuM-6p-Q58xmQ0");


            var me = botClient.GetMeAsync().Result;
            Console.WriteLine(
              $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );


            botClient.OnMessage += Bot_OnMessage;
            botClient.OnCallbackQuery += Bot_OnCallbackQuery;
            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }



        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            ReplyKeyboardMarkup ReplyKeyboard = new[]
                    {
                        new[] { "First Request", "First Five Requests" },
                        new[] { "Fisrt fifteen", "Send everything" },
                        new[] { "⚠️Abracadabra⚠️" }
};//might be adjusted for optimization








            if (e.Message.Text != null)
            {
                holder = Convert.ToString(Regex.Replace(e.Message.Text, "([^a-z+])", "", options: RegexOptions.IgnoreCase));
                if (holder.Equals("FirstRequest", StringComparison.InvariantCultureIgnoreCase) )
                {
                   if (buyer.Count != 0) { message = await botClient.SendPhotoAsync(
                    chatId: e.Message.Chat.Id,
                    photo: Convert.ToString(product.Dequeue()),
                    caption: "@" + Convert.ToString(buyer.Dequeue())
                    );
                }


                }
                else if (holder.Equals("FirstFiveRequests", StringComparison.InvariantCultureIgnoreCase))
                {
                    int i = 5;
                    while (i > 0 && buyer.Count != 0)
                        message = await botClient.SendPhotoAsync(
                        chatId: e.Message.Chat.Id,
                        photo: Convert.ToString(product.Dequeue()),
                        caption: "@" + Convert.ToString(buyer.Dequeue())
                        );


                }

                else if (holder.Equals("Fisrtfifteen", StringComparison.InvariantCultureIgnoreCase))
                {
                    int i = 15;
                    while (i > 0 && buyer.Count != 0)
                        message = await botClient.SendPhotoAsync(
                        chatId: e.Message.Chat.Id,
                        photo: Convert.ToString(product.Dequeue()),
                        caption: "@" + Convert.ToString(buyer.Dequeue())
                        );
                    i--;


                }
                else if (holder.Equals("Sendeverything", StringComparison.InvariantCultureIgnoreCase))
                {

                    while (buyer.Count != 0)
                        message = await botClient.SendPhotoAsync(
                        chatId: e.Message.Chat.Id,
                        photo: Convert.ToString(product.Dequeue()),
                        caption: "@" + Convert.ToString(buyer.Dequeue())
                        );
                }
                else if (holder.Equals("abracadabra", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (e.Message.From.Id == my && primary_channel != "@flashersheaven")
                    {
                        primary_channel = "@flashersheaven";
                        holder = primary_channel;
                        hiphop = "@hiphopflash";
                        rick_and_morty = "@rickandmortyflash";
                        inde = "@indeflash";
                        sports = "@sportflash";
                        marvel = "@Marvelsflash";
                        anime = primary_channel;
                        art = "@artisticflash";
                        starwars = primary_channel;
                        space = "@artisticflash";
                        got = primary_channel;
                        rock = "@rocksflash";
                        action = primary_channel;
                        commical = primary_channel;
                        others = primary_channel;
                        //optimizable

                    }
                    else if (e.Message.From.Id == my)
                    {
                        holder = Convert.ToString(my);
                        primary_channel = holder;
                        hiphop = holder;
                        rick_and_morty = holder;
                        inde = holder;
                        sports = holder;
                        marvel = holder;
                        anime = holder;
                        art = holder;
                        starwars = holder;
                        space = holder;
                        got = holder;
                        rock = holder;
                        action = holder;
                        commical = holder;
                        others = holder;
                        //optimizable

                    }
                    else
                    {
                        message = await botClient.SendTextMessageAsync(
                           chatId: e.Message.Chat.Id,
                           text: "🚫You are not an authorized user🚫"
                           );
                        message = await botClient.SendTextMessageAsync(
                            chatId: Convert.ToString(my),
                            text: "user @" + e.Message.From.Username + " tried clicking abracadabra"
                           );
                    }

                }
                else if (holder.Equals("Lambardia", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (e.Message.From.Id == my)
                    {
                        botClient.StopReceiving();

                    }
                    else
                    {
                        message = await botClient.SendTextMessageAsync(
                           chatId: e.Message.Chat.Id,
                           text: "🚫You are not an authorized user🚫"
                           );
                        message = await botClient.SendTextMessageAsync(
                            chatId: Convert.ToString(my),
                            text: "user @" + e.Message.From.Username + " just entered Lambardia"
                           );
                    }
                }
                else message = await botClient.SendTextMessageAsync(
                          chatId: e.Message.Chat.Id,
                          text: "Unrecogized Input"
                          );

                if (buyer.Count == 0)


                {
                    message = await botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat.Id,
                        text: "You have no more orders",
                        disableNotification: true
                        );

                }




            }
            if (e.Message.Photo != null)
            {


                e.Message.Caption = Convert.ToString(Regex.Replace(e.Message.Caption, "([^a-z+])", "", options: RegexOptions.IgnoreCase));


                if ("primary".Equals(e.Message.Caption, StringComparison.InvariantCultureIgnoreCase))
                    holder = primary_channel;
                else if ("rickandmorty".Equals(e.Message.Caption, StringComparison.InvariantCultureIgnoreCase))
                    holder = rick_and_morty;
                else if ("inde".Equals(e.Message.Caption, StringComparison.InvariantCultureIgnoreCase))
                    holder = inde;
                else if ("sports".Equals(e.Message.Caption, StringComparison.InvariantCultureIgnoreCase))
                    holder = sports;
                else if ("marvel".Equals(e.Message.Caption, StringComparison.InvariantCultureIgnoreCase))
                    holder = marvel;
                else if ("anime".Equals(e.Message.Caption, StringComparison.InvariantCultureIgnoreCase))
                    holder = anime;
                else if ("art".Equals(e.Message.Caption, StringComparison.InvariantCultureIgnoreCase))
                    holder = art;
                else if ("starwars".Equals(e.Message.Caption, StringComparison.InvariantCultureIgnoreCase))
                    holder = starwars;
                else if ("space".Equals(e.Message.Caption, StringComparison.InvariantCultureIgnoreCase))
                    holder = space;
                else if ("hiphop".Equals(e.Message.Caption, StringComparison.InvariantCultureIgnoreCase))
                    holder = hiphop;
                else if ("gameofthrones".Equals(e.Message.Caption, StringComparison.InvariantCultureIgnoreCase))
                    holder = got;
                else if ("rock".Equals(e.Message.Caption, StringComparison.InvariantCultureIgnoreCase))
                    holder = rock;
                else if ("action".Equals(e.Message.Caption, StringComparison.InvariantCultureIgnoreCase))
                    holder = action;
                else if ("commical".Equals(e.Message.Caption, StringComparison.InvariantCultureIgnoreCase))
                    holder = commical;
                else if ("others".Equals(e.Message.Caption, StringComparison.InvariantCultureIgnoreCase))
                    holder = others;
                else
                {
                    message = await botClient.SendTextMessageAsync(
                     chatId: e.Message.Chat.Id,
                     text: "Wrong Caption Attacment"
                     );
                    holder = "mamari";

                }
                if (holder != "mamari")
                    message = await botClient.SendPhotoAsync(
                        chatId: holder,
                        photo: e.Message.Photo[0].FileId,
                        caption: "Available in store - " + available,
                        replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithCallbackData(
                            text: "order",
                            callbackData: "yan"
                        )
                            )
                        );
                message = await botClient.SendTextMessageAsync(
                    chatId: "@flashersheaven",
                    text: Convert.ToString(e.Message.Photo[0].FileId)
                    );

            }
        }
        static async void Bot_OnCallbackQuery(object sender, CallbackQueryEventArgs e)
        {


            if (e.CallbackQuery.Id != null)
            {


                if (e.CallbackQuery.Message.Caption != "****All RESERVED****" && (Convert.ToInt16(Convert.ToString(Regex.Match(input: e.CallbackQuery.Message.Caption, pattern: @"[0-9]+"))) > 1 && !buyer.Contains(e.CallbackQuery.From.Username)))
                {
                    buyer.Enqueue(e.CallbackQuery.From.Username);
                    product.Enqueue(e.CallbackQuery.Message.Photo[0].FileId);
                    botClient.EditMessageCaptionAsync(chatId: e.CallbackQuery.Message.Chat.Id,
                        messageId: e.CallbackQuery.Message.MessageId,
                        caption: "Available in store - " + Convert.ToString(Convert.ToInt16(Convert.ToString(Regex.Match(input: e.CallbackQuery.Message.Caption, pattern: @"[0-9]+"))) - 1),
                        replyMarkup: new InlineKeyboardMarkup(inlineKeyboardButton: InlineKeyboardButton.WithCallbackData(text: "order", callbackData: "yan")
                            )
                        );
                    botClient.AnswerCallbackQueryAsync(callbackQueryId: e.CallbackQuery.Id, showAlert: false, text: "Your Order has been requested 👍");
                }
                else if (e.CallbackQuery.Message.Caption != "****All RESERVED****" && (Convert.ToInt16(Convert.ToString(Regex.Match(input: e.CallbackQuery.Message.Caption, pattern: @"[0-9]+"))) == 1 && !buyer.Contains(e.CallbackQuery.From.Username)))
                {
                    buyer.Enqueue(e.CallbackQuery.From.Username);
                    product.Enqueue(e.CallbackQuery.Message.Photo[0].FileId);

                    botClient.EditMessageCaptionAsync(chatId: e.CallbackQuery.Message.Chat.Id,
                        messageId: e.CallbackQuery.Message.MessageId,
                        caption: "****All RESERVED****",
                        replyMarkup: new InlineKeyboardMarkup(inlineKeyboardButton: InlineKeyboardButton.WithCallbackData(text: "order", callbackData: "h")
                            )

                        );

                    botClient.AnswerCallbackQueryAsync(callbackQueryId: e.CallbackQuery.Id, showAlert: false, text: "Your Order has been requested 👍");
                }
                else if (e.CallbackQuery.Message.Caption == "****All RESERVED****")
                {

                    botClient.AnswerCallbackQueryAsync(callbackQueryId: e.CallbackQuery.Id, showAlert: false, text: "Sorry all units are currently reserved 😔");

                }
                else botClient.AnswerCallbackQueryAsync(callbackQueryId: e.CallbackQuery.Id, showAlert: false, text: "Your previose order is Still inprogress 🥶");

            }

        }
    }
}